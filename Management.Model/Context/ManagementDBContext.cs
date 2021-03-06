using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Model.Context
{
    public class ManagementDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = Management.Settings.Services.ConnectionStringAppDb();
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(conn);
        }

    }
}
