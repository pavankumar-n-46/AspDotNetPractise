using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.data;

namespace Dot_net_core.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurauntData;

        public string Message;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }


        public ListModel(IConfiguration config, IRestaurantData restaurauntData)
        {
            this.config = config;
            this.restaurauntData = restaurauntData;
        }


        public void OnGet()
        {
            Message = config["Message"];
            Restaurants = restaurauntData.GetAllRestaurantsByName(SearchTerm);
        }
    }
}