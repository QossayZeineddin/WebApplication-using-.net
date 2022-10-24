using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
            : base(options)
        {
        }
     

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     // connect to mysql with connection string from app settings
        //     //var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        //
        //     options.UseMySQL("server=3306 ; database = dotnet_test ;uid = root , pwd = root123;");
        // }

        public DbSet<WebApplication1.Models.users> users { get; set; } = default!;
    }
}