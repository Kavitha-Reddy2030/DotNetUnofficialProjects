using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDataAccess
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyDatabaseConnection")
        {
        }

        public DbSet<MyEntity> MyEntities { get; set; }
    }


}
