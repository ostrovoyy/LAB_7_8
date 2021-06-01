using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.EF
{
    public class DistrictListContext : DbContext
    {
        public DbSet<Citizen> Users { get; set; }
        public DbSet<District> Districts { get; set; }

        public DistrictListContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
