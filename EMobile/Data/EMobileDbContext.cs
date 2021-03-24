using EMobile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMobile.Data
{
    public class EMobileDbContext : DbContext
    {
        public EMobileDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MobileEntity> Mobiles { get; set; }
    }
}
