using APBD_TASK2.Enum;

namespace APBD_TASK2.Models
{
    public abstract class Equipment
    {
        private static int _nextId = 1;
        public int Id{  get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public EquipmentStatus Status { get; set; }

        protected Equipment(string name, string description, DateTime addedDate) {
            Id = _nextId++;
            Name = name;
            Description = description;
            AddedDate = DateTime.Now;
            Status = EquipmentStatus.Available;
        }

    
    }
}