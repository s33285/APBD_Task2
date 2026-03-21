namespace APBD_TASK2.Models
{
    public class Rental
    {
        private static int _nextId = 1;
        public int Id { get; }
        public User User { get; set; }
        public Equipment Equipment { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned => ReturnDate.HasValue;
        public decimal Penalty { get; set; }


        public Rental(User user, Equipment equipment, int days)
        {
            Id = _nextId++;
            User = user;
            Equipment = equipment;
            RentalDate = DateTime.Now;
            DueDate = RentalDate.AddDays(days);
        }
    }
}