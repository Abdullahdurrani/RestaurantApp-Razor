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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            // get Restaurant by Id if null redirect to NotFound page
            Restaurant = restaurantData.GetById(restaurantId);
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            // Delete returns the deleted restuarant object, here we store it in var restaurant 
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if(restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            // to display the deleted message used TempData
            TempData["Message"] = $"{restaurant.Name} deleted!";
            return RedirectToPage("./List");
        }
    }
}
