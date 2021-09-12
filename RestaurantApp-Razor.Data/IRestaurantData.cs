using RestaurantApp_Razor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_Razor.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "ABC", Location = "Italy", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "XYZ", Location = "Spain", Cuisine = CuisineType.Spanish},
                new Restaurant {Id = 3, Name = "GHI", Location = "Mexico", Cuisine = CuisineType.Mexican},
            };
        }


        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
