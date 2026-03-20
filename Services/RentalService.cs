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
        
        
        }

    }
}