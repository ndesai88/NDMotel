using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NDMotel.Data;
using NDMotel.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NDMotel.Controllers
{
    public class UpdateReservationController : Controller
    {
        private readonly NDMotelContext _motelContext;

        public UpdateReservationController(NDMotelContext context)
        {
            _motelContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost]
        public IActionResult Index(string reservationID)
        {
            
            var reservation = (from rr in _motelContext.RoomReservations
                              join guest in _motelContext.Guests
                              on rr.GuestID equals guest.ID
                              join rt in _motelContext.RoomTypes
                              on rr.RoomTypeID equals rt.ID
                              where rr.ID == Convert.ToInt32(reservationID)
                              select new
                                { rr.checkIn, rr.checkOut, guest.FirstName, guest.LastName, guest.Address, guest.PhoneNumber, guest.ZipCode, rt.RoomName });

            
            
            var existingReservation = new ExistingReservation();
            if (reservation != null)
            {
                existingReservation.FirstName = reservation.Select(x => x.FirstName).FirstOrDefault();
                existingReservation.LastName = reservation.Select(x => x.LastName).FirstOrDefault();
                existingReservation.Address = reservation.Select(x => x.Address).FirstOrDefault();
                existingReservation.PhoneNumber = reservation.Select(x => x.PhoneNumber).FirstOrDefault();
                existingReservation.ZipCode = reservation.Select(x => x.ZipCode).FirstOrDefault(); 
                existingReservation.ReservationID = Convert.ToInt32(reservationID);
            }
            
            
            return View(existingReservation);
        }

        [HttpPost]
        public IActionResult Update(ExistingReservation updateReservation, String Modifybtn)
        {
           
             
            switch (Modifybtn)
            {
                case "Update Reservation":
                    var guestID = _motelContext.RoomReservations.Where(p => p.ID == updateReservation.ReservationID).Select(p => p.GuestID).First();
                    var existingGuest = _motelContext.Guests.Where(p => p.ID == guestID).Select(p => p).First();
                    
                    if (existingGuest != null)
                    {
                        existingGuest.FirstName = updateReservation.FirstName;
                        existingGuest.LastName = updateReservation.LastName;
                        existingGuest.Address = updateReservation.Address;
                        existingGuest.PhoneNumber = updateReservation.PhoneNumber;
                        existingGuest.ZipCode = updateReservation.ZipCode;

                    }

                    _motelContext.SaveChanges();

                    ViewBag.Message = "Customer Details successfully!";
                    break;
                case "Cancel Reservation":
                    var reservation = _motelContext.RoomReservations.Where(p => p.ID == updateReservation.ReservationID).Select(p => p).First();
                    var guest = _motelContext.Guests.Where(p => p.ID == reservation.GuestID).Select(p => p).First();

                    _motelContext.RoomReservations.Remove(reservation);
                    _motelContext.Guests.Remove(guest);

                    _motelContext.SaveChanges();

                    ViewBag.Message = "The operation is complete. Reservation is now Cancelled!";
                    break;
            }


            return View("UpdateConfirm");

        }   
    }
}
