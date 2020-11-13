using HotelRecord.Repository.Moduls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelRecord.Repository
{
    public class HotelRecordDbContext : DbContext
    {

        public HotelRecordDbContext(DbContextOptions<HotelRecordDbContext> options) : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<HotelChain> HotelChains { get; set; }
    }
}
