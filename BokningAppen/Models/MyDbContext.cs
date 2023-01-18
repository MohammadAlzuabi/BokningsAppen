using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BokningsAppen1.Models
{
    internal class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Bookingapp;Trusted_Connection=True;");
        }

        public DbSet<ConferenceRoom>? Rooms { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
    }     
}
