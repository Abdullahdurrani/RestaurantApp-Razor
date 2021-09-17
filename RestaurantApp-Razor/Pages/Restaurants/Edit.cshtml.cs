using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantApp_Razor.Core;
using RestaurantApp_Razor.Data;

namespace RestaurantApp_Razor.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        // provides methods like GetEnumSelectList which builds collection of list of items based on enumtype
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        [BindProperty] // receives data and populates this property instead of creating a new updatedRestaurant property
        // since we are not receiving data in OnGet like SearchTerm in Index page we are not using (SupportsGet=true)
        // which means only use this as input property in OnPost method, and is used as output prop in OnGet as usual.
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        // is set optional because we are using same page for create functionality
        public IActionResult OnGet(int? restaurantId)
        {
            // builds collection of list of items based on enumtype
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

            // if id is passed populate the Restaurant 
            if(restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            // otherwise create new Restaurant object
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            // checks for validation and if form submission is not valid
            // if not valid then we show same page
            if (!ModelState.IsValid)
            {
                // When we click update button then all other fields are populated because of Restaurant property ( using BinProperty) 
                // but we are populating cuisines using htmlHelper so it is needed in OnPost too
                // otherwise on Update button the cuisine selection will be empty
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();         
            }
            // if id is greater than 0 {database id is greater than 0 } then call update method
            if(Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
                // tempdata shows temporary message and then disappears, make a property in the page you want to display it ( here it is Detail page)
                TempData["Message"] = "Restaurant Updated!";
            }
            // otherwise call Add method
            else
            {
                restaurantData.Add(Restaurant);
                TempData["Message"] = "New Restaurant Created!";
            }

            // commit save changes to the database
            restaurantData.Commit(); 

            // we redirect to other page because if we show same page after update
            // and then user refreshes the browser it shows form resubmission 
            // meaning data is sent 2 times { e.g a user will be charged 2 times if he refreshed the browser after form submission }
            // we pass restaurantId in an object because it is required in Detail page
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });


        }
    }
}
