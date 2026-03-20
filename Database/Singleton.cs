using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APBD_TASK2.Database
{
    public class Singleton
    {
        private static Singleton? _instance;
        public static Singleton Instance
        {
            get
            {
                _instance ??= new Singleton();
                return _instance;
            }
        }

        private Singleton() { }

        //TODO: add collections for items in the exercise
        public List<User> Users { get; set; } = new();
        public List<Equipment> EquipmentItems { get; set; } = new();
        public List<Rental> Rentals { get; } = new();
        
    }
}
