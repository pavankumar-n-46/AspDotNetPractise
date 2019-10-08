using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.data;

namespace Dot_net_core.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantID)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantID.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(restaurantID.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if(Restaurant != null)
            {
                return Page();
            }
            return RedirectToPage("./NotFound");
        }

        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if(Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
            }
            else
            {
                restaurantData.Add(Restaurant);
            }
  
            restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantID = Restaurant.Id });
        }
    }
}