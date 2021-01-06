using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudExample
{
    public class ETradeContext : DbContext
    {
        /*
         * Bu tablolarda Products diye bişi arıyor. Databse de var
         */
        public DbSet<Product> Products { get; set; }
    }
}
