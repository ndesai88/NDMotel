using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDMotel.Models
{
    public class MotelProperties
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }

        public ICollection<RoomInventory> RoomInventory { get; set; }
        public ICollection<RoomReservation> RoomReservation { get; set; }
    }
}
