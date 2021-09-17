using RestaurantApp_Razor.Core;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp_Razor.Data
{
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

        // this method doesn't do anythings for now
        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int id)
        {
            // returns single restaurant or default (null)
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   // get all if no parameter is passed or get which matches with name param
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            // Adds to List of restaurants -> will change for database implementation
            restaurants.Add(newRestaurant);

            // returns max id in restaurants list and adds one to it then assigns it to the newRestaurant
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            // returns restaurant if id matches the updatedRestaurant id otherwise returns null
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                // updates values to the new updated values
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }
    }
}
