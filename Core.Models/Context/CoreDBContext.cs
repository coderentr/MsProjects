using Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Context
{
    public class CoreDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = Settings.Services.ConnectionStringAppDb();
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(conn);
        }
        public DbSet<USER> Users { get; set; }
    }
}
