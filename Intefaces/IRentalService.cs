using APBD_TASK2.Models;

namespace APBD_TASK2.Interfaces
{
    public interface IRentalService
    {
        void AddUser(User user);
        void AddEquipment(Equipment equipment);
        List<Equipment> GetAllEquipment();
        List<Equipment> GetAllAvailableEquipment();

        void RentEquipment(int userId, int equipmentId, int days);

        void ReturnEquipment(int equipmentId);

        List<Rental> GetUserActiveRentals(int userId);
        List<Rental> GetOverdueRentals();

        string GenerateReport();
       
    }
}