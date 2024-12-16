using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication6;

namespace WebApplication6.Data
{
    public class WebApplication6Context : DbContext
    {
        public WebApplication6Context (DbContextOptions<WebApplication6Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication6.Client> Client { get; set; } = default!;

        public DbSet<WebApplication6.Employee> Employee { get; set; } = default!;

        public DbSet<WebApplication6.Request> Request { get; set; } = default!;

        public DbSet<WebApplication6.Service> Service { get; set; } = default!;
    }
}
