using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NDMotel.Models
{
    public class RoomInventory
    {
        public int ID { get; set; }
        public int RoomTypeID { get; set; }
        public int NumberOfRooms { get; set; }
        public int BestPrice { get; set; }
        public int HighestPrice { get; set; }
        public int MotelPropertiesID { get; set; }

        public RoomType RoomType { get; set; }
        public MotelProperties MotelProperties { get; set; }
    }

    
}
