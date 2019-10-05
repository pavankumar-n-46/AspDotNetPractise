using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;

namespace Dot_net_core.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant;

        public void OnGet(int restaurantID)
        {
            Restaurant = new Restaurant();
            Restaurant.Id = restaurantID;
        }
    }
}