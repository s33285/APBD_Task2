using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services
{
    public class RentalService : IRentalService
    {
        private readonly Singleton _db = Singleton.Instance;

        public void AddUser(User user)
        {
            _db.Users.Add(user);
        }

        public void AddEquipment(Equipment equipment)
        {
            _db.EquipmentItems.Add(equipment);
        }

        public List<Equipment> GetAllEquipment()
        {
            return _db.EquipmentItems;
        }


        public List<Equipment> GetAllAvailableEquipment() {
            return _db.EquipmentItems.Where(e => e.Status == EquipmentStatus.Available).ToList();
        }

        public void RentEquipment(int userId, int equipmentId, int days)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            var equipment = _db.EquipmentItems.FirstOrDefault(e => e.Id == equipmentId);

            if (user == null || equipment == null)
                throw new Exception("User or Equipment not found");

            if (equipment.Status != EquipmentStatus.Available)
                throw new Exception("Equipment is not available");

            var activeRentals = _db.Rentals
                .Count(r => r.User.Id == userId && !r.IsReturned);

            if (activeRentals >= GetMaxRentals(user))
                throw new Exception("User exceeded rental limit");

            var rental = new Rental(user, equipment, days);

            equipment.Status = EquipmentStatus.Rented;
            _db.Rentals.Add(rental);
        }

        public void ReturnEquipment(int equipmentId)
        {
            var rental = _db.Rentals
                .FirstOrDefault(r => r.Equipment.Id == equipmentId && !r.IsReturned);

            if (rental == null)
                throw new Exception("Active rental not found");

            rental.ReturnDate = DateTime.Now;

            rental.Equipment.Status = EquipmentStatus.Available;

            if (rental.ReturnDate > rental.DueDate)
            {
                var lateDays = (rental.ReturnDate.Value - rental.DueDate).Days;
                rental.Penalty = lateDays * 5;
            }
        }

        public List<Rental> GetUserActiveRentals(int userId)
        {
            return _db.Rentals
                .Where(r => r.User.Id == userId && !r.IsReturned)
                .ToList();
        }

        public List<Rental> GetOverdueRentals()
        {
            return _db.Rentals
                .Where(r => !r.IsReturned && r.DueDate < DateTime.Now)
                .ToList();
        }


        public string GenerateReport()
        {
            return $"Users: {_db.Users.Count}, Equipment: {_db.EquipmentItems.Count}, Rentals: {_db.Rentals.Count}";
        }

        private int GetMaxRentals(User user)
        {
            return user.Type == UserType.Student ? 2 : 5;
        }


        public void MarkEquipmentUnavailable(int equipmentId)
        {
            var equipment = _db.EquipmentItems.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment == null) throw new Exception("Equipment not found");
            equipment.Status = EquipmentStatus.Unavailable;

        }
    }
}