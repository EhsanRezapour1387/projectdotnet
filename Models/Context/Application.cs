
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectdotnet.Models.Data;

namespace projectdotnet.Models.Context
{
    public class Application : DbContext
    {
        public Application(DbContextOptions<Application> options) : base(options) { }
        public DbSet<Tbl_Header> tbl_Headers { get; set; }
        public DbSet<Tbl_Offer> tbl_Offers { get; set; }
        public DbSet<Tbl_User> tbl_Users { get; set; }
    }
}