using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DigitalRetailersInc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DigitalRetailersInc.Data
{
    public class DigitalRetailersIncContext : IdentityDbContext
    {
        public DigitalRetailersIncContext (DbContextOptions<DigitalRetailersIncContext> options)
            : base(options)
        {
        }

        public DbSet<DigitalRetailersInc.Models.LaptopDetails> LaptopDetails { get; set; } = default!;

        public DbSet<DigitalRetailersInc.Models.Myorders> Myorders { get; set; } = default!;



        //public DbSet<DigitalRetailersInc.Models.Orders>? Orders { get; set; }
    }
}
