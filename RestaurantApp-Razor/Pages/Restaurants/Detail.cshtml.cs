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
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            // retreives the restaurant by the id passed 
            Restaurant = restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            // renders the page
            return Page();
        }
    }
}
