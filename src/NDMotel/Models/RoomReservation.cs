using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDMotel.Models
{
    public class RoomReservation
    {
        public int ID { get; set; }
        public int RoomTypeID { get; set; }
        public int GuestID { get; set; }
        public int MotelPropertiesID { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        
        public Guest Guest { get; set; }
        public RoomType RoomType { get; set; }
        public MotelProperties MotelProperties { get; set; }
        
    }
}
