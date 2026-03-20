namespace APBD_TASK2.Models
{
    public class Camera : Equipment
    {
        public int Resolition { get; set; }
        public int Memory { get; set; }
        public bool HasVideo { get; set; }

        public Camera(string name, string description, int resolition, int memory, bool hasVideo)
            : base(name, description)
        { 
            Resolition = resolition;
            Memory = memory;
            HasVideo = hasVideo;
        }
    }
}