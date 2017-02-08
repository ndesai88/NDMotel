using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDMotel.Models;
using Microsoft.EntityFrameworkCore;

namespace NDMotel.Data
{
    public class NDMotelContext : DbContext
    {
        public NDMotelContext(DbContextOptions<NDMotelContext> options) : base(options)
        {
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomInventory> RoomInventory { get; set; }
        public DbSet<MotelProperties> MotelProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().ToTable("Guest");
            modelBuilder.Entity<RoomReservation>().ToTable("RoomReservation");
            modelBuilder.Entity<RoomType>().ToTable("RoomType");
            modelBuilder.Entity<RoomInventory>().ToTable("RoomInventory");
            modelBuilder.Entity<MotelProperties>().ToTable("MotelProperties");
        }
    }
}
