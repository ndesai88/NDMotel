using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NDMotel.Models
{
    public class RoomType
    {
        public int ID { get; set; }
        [Display(Name ="Room Discription")]
        public string RoomDescription { get; set; }
        [Display(Name ="Room Name")]
        public string RoomName { get; set; }

        public ICollection<RoomReservation> RoomReservation { get; set; }
        public ICollection<RoomInventory> RoomInventory { get; set; }
    }
}
