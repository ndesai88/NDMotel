﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NDMotel.Models
{
    public class ExistingReservation
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public string ZipCode { get; set; }
            
            public int ReservationID { get; set; }
    }
}
