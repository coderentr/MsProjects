using Core.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public static class Service
    {
        public static void RunMigration()
        {
            using (var db = new CoreDBContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
