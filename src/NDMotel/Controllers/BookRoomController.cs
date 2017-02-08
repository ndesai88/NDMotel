using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NDMotel.Models;
using NDMotel.Data;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NDMotel.Controllers
{
    public class BookRoomController : Controller
    {

        private readonly NDMotelContext _motelContext;


        public BookRoomController(NDMotelContext context)
        {
            _motelContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BookRoom confirmBooking, String btnbookroom)
        {
            var roomName = _motelContext.RoomTypes.Where(p => p.RoomName == btnbookroom).Select(p=>p.RoomName).FirstOrDefault();
            var roomTypeID = _motelContext.RoomTypes.Where(p => p.RoomName == roomName).Select(x => x.ID).FirstOrDefault();
            var guestID = _motelContext.Guests.Where(p => p.FirstName == confirmBooking.firstName && p.LastName == confirmBooking.lastName).Select(x => x.ID).FirstOrDefault();
            var locationID = 1;
            Guest g = new Guest() { 
                FirstName = confirmBooking.firstName,
                LastName = confirmBooking.lastName,
                Address = confirmBooking.address,
                PhoneNumber = confirmBooking.phoneno,
                ZipCode = confirmBooking.zipcode
            } ;
           
            RoomReservation confirmRoomReservation = new RoomReservation()
            {
                RoomTypeID = roomTypeID,
                GuestID = g.ID,
                checkIn = confirmBooking.checkinDate,
                checkOut = confirmBooking.checkoutDate,
                MotelPropertiesID = locationID
            };
            confirmRoomReservation.Guest = g;
            _motelContext.RoomReservations.Add(confirmRoomReservation);


            //_motelContext.Entry(confirmRoomReservation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _motelContext.SaveChanges();

            ViewData["ReservationID"] = confirmRoomReservation.ID;
            
            return View(confirmRoomReservation);
        }
    }
}
       

