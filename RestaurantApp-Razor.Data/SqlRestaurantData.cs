using Microsoft.EntityFrameworkCore;
using RestaurantApp_Razor.Core;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp_Razor.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantAppDbContext dbContext;

        // dbcontext is used by every method to get specific functions
        public SqlRestaurantData(RestaurantAppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            // either dbContext.Add or dbContext.Restaurants.Add both are same
            dbContext.Add(newRestaurant);
            return newRestaurant;
        }

        // saves changes to database
        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            // get restaurant object by id
            var restaurant = GetById(id);

            // if found remove it from database
            if (restaurant != null)
            {
                dbContext.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            // ef returns restaurant object if it is found or returns the null
            return dbContext.Restaurants.Find(id);
        }

        public int GetCountOfRestaurants()
        {
            return dbContext.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in dbContext.Restaurants
                        // gets all if no parameter is passed or get which matches with name param
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            // Attach tells ef core the object is already in database but track changes to it
            var entity = dbContext.Restaurants.Attach(updatedRestaurant);
            // object context must know state of object to save changes to database accordingly
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
