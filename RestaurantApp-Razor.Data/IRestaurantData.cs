using RestaurantApp_Razor.Core;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp_Razor.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
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


        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   // get all if no parameter is passed or get which matches with name param
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
