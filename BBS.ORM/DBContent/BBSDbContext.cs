using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BBS.ORM.DBContent
{
    public class BBSDbContext<T>:DbContext where T: class
    {

        public BBSDbContext(DbContextOptions<BBSDbContext<T>> options) : base(options)
        {

        }
        public DbSet<T>  Table { get; set; }
    }
}
