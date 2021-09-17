using Microsoft.EntityFrameworkCore;
using RestaurantApp_Razor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_Razor.Data
{
    // DbContext class is used to work with database
    public class RestaurantAppDbContext : DbContext
    {
        public RestaurantAppDbContext(DbContextOptions<RestaurantAppDbContext> options) : base(options)
        {

        }


        // tells efcore to query for Restaurant info and can also do CRUD on info
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
