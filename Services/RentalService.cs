using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services
{
    public class RentalService : IRentalService
    {
        private readonly Singletopn _db = Singleton.Instance;

        public AddUser(User user)
        { 
            _db.Users.Add(user);
        }

        public AddEquipment(Equipment equipment)
        { 
            _db.EquipmentItems.Add(equipment);
        }

        public List<Equipment> GetAllAvailableEquipment() {
            return _db.EquipmentItems
                   .Where(equals => e.Status == EquipmentStatus.Available)
                   .ToList();
        }

        public RentEquipment(int userId, int equipment, int days)
        { 
            var user = _db.User.FirstOrDefault(u => u.Id == userId);
            var equipmet = _db.EquipmentItems.FirstOrDefault(e => e.Id == equipmentId);

           var rental = new Rental(user, equipment, days);

            equipment.Status = EquipmentStatus.Rented;
            _db.Rentals.Add(rental);

            if (user == null || equipmet == null)
                throw new Exception("User or Equipment not found");

            if (equipment.Status != EquipmentStatus.Available)
                throw new Exception("Equipment is not available");

            var activeRentals = _db.Rentals
                .Count(r => r.User.Id == userId && !r.IsReturned);
            if (activeRentals >= GetMaxRentals(user))
                throw new Exception("User exceeded rental limit");
        
        }

        public ReturnedEquipment(int equipment)
        { 
            var rental = _db.Rentals
                 .FirstOrDefault(r => r.Equipment.Id == equipmentId && !r.IsReturned);
            if (rental == null) throw new Exception("Active rental not found");

            rental.ReturnDate = DateTime.Now;
            rental.Equipment.Status = EquipmentStatus.Available;

            if (rental.ReturnedDate > rental.DueDate)
            { 
                var lateDays = (rental.ReturnDate.Value - rental.DueDate).Days;
                rental.Penalty = lateDays * 5;
            }
        }



    }
}