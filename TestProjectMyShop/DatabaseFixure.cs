using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMyShop
{
    public class DatabaseFixure
    {
        public ProductContext Context { get; private set; }
        public DatabaseFixure()
        {
            var options = new DbContextOptionsBuilder<ProductContext>()
                .UseSqlServer("Server = SRV2\\PUPILS; Database = My_tmpData; Trusted_Connection = True; TrustServerCertificate = True")
                .Options;
            Context = new ProductContext(options);
            Context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            Context.Database.EnsureCreated();
            Context.Dispose();
        }
    }
}
