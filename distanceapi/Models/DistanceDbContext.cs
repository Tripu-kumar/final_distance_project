using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace distanceapi.Models
{
    public class DistanceDbContext : DbContext
    {
        public DistanceDbContext(DbContextOptions<DistanceDbContext> options) : base(options)
        {

        }
        public DbSet<distance> GetDistances { get; set; }
    }
}
