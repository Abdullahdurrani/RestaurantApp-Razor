using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantApp_Razor.Core;
using RestaurantApp_Razor.Data;

namespace RestaurantApp_Razor.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        //to get restaurants
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)] // tells this property receives info from request
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            // gets all restaurants objects or those searched
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
