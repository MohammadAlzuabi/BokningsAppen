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
            optionsBuilder.UseSqlServer("Server=tcp:mohammad2.database.windows.net,1433;Initial Catalog=BokningAppen;Persist Security Info=False;User ID=mohammad;Password=alzuabi1#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<ConferenceRoom>? Rooms { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
    }     
}
