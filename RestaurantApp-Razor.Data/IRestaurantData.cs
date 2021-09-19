using RestaurantApp_Razor.Core;
using System.Collections.Generic;

namespace RestaurantApp_Razor.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);

        // for Creating new Restaurant
        Restaurant Add(Restaurant newRestaurant);

        // for OnPost method. Gets updated object and assigns it to the older one
        Restaurant Update(Restaurant updatedRestaurant);
        // similar to SaveChanges in ef core for in memory database. But is not implemented yet

        Restaurant Delete(int id);

        int GetCountOfRestaurants();

        // saves changes to the database
        int Commit();
    }
}
