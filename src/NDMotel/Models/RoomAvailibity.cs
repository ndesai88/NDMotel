using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NDMotel.Models
{
    public class CheckAvailibity
    {
        public string Location { get; set; }
        public string checkInDate { get; set; }
        public string checkOutDate { get; set; }
        public string numOfPeople { get; set; }
    }

    public class ReturnAvailibility
    {

        public string Name { get; set; }
        public string Description { get; set; }
        //public int HighestPrice { get; set; }
        public int LowestPrice { get; set; }
    }

    public class BookRoom
    {
        public List<ReturnAvailibility> RoomDetail { get; set; } 

        public int locationid { get; set;}
        [Required]
        public int noofpeope { get; set; }
        [Required(ErrorMessage = "Please enter the user's first name.")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Please enter the user's last name.")]
        public string lastName { get; set; }
        [Required]
        public DateTime checkinDate { get; set; }
        [Required]
        public DateTime checkoutDate { get; set; }
        [Required(ErrorMessage = "Please enter the user's Address.")]
        public string address { get; set; }
        [Required(ErrorMessage = "Please enter the user's Zipcode.")]
        public string zipcode { get; set; }
        [Required(ErrorMessage = "Please enter the user's Phone No.")]
        public string phoneno { get; set; }
    }
}
