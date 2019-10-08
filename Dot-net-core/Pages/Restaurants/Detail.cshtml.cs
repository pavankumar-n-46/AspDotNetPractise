using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.data;

namespace Dot_net_core.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant;

        [TempData]
        public string Message { get; set; }

        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantID)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantID);
            if (Restaurant != null)
            {
                return Page();
            }

            return RedirectToPage("./NotFound");
        }
    }
}