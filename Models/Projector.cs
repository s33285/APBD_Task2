namespace APBD_TASK2.Models
{
    public class Projector : Equipment
    { 
        public int Lumens { get; set; }
        public bool IsPortable { get; set; }

        public Projector(string name, string description, int lumens, bool isPortable)
            : base(name, description)
        {
            Lumens = lumens;
            IsPortable = isPortable;
        }
    }
}