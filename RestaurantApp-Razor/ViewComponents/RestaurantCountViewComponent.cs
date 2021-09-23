using Microsoft.AspNetCore.Mvc;
using RestaurantApp_Razor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp_Razor.ViewComponents
{
    // view componenet is embeded into some other view like partial view but unlike partial view it doesnt have model binding.
    // only depends on data provided to it
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        // same as IActionResult but here it render View
        // Pages/Shared/Components/RestaurantCount/Default
        public IViewComponentResult Invoke()
        {
            string MyView = "Default";
            var count = restaurantData.GetCountOfRestaurants();
            return View(MyView, count);
        }
    }
}
