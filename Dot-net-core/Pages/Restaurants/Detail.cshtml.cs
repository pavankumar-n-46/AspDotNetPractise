﻿using System;
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
        public readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public void OnGet(int restaurantID)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantID);
        }
    }
}