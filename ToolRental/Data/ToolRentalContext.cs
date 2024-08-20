using Microsoft.EntityFrameworkCore;
using ToolRental.Models;
using System.Configuration;

namespace ToolRental.Data
{
    public class ToolRentalContext : DbContext
    {
        public ToolRentalContext (DbContextOptions<ToolRentalContext> options)
            : base(options)
        {
        }

        public DbSet<ToolReservation> ToolReservation { get; set; } = default!;
        public DbSet<ToolRenter> Renters { get; set; }
        public DbSet<Tool> Tool { get; set; } = default!;
    }
}
