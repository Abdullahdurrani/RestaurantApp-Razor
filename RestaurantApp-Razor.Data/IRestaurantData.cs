﻿using RestaurantApp_Razor.Core;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp_Razor.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        // for OnPost method. Gets updated object and assigns it to the older one
        Restaurant Update(Restaurant updatedRestaurant);
        // similar to SaveChanges in ef core for in memory database. But is not implemented yet
        int Commit();
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
    }
}
