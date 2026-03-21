namespace APBD_TASK2.Models
{
    public class Camera : Equipment
    {
        public int Resolition { get; set; }
        public bool HasVideo { get; set; }

        public Camera(string name, string description, int resolition, bool hasVideo)
                    : base(name, description)
        { 
            Resolition = resolition;
            HasVideo = hasVideo;
        }
    }
}