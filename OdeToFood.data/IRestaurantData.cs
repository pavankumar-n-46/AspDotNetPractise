using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace OdeToFood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Domino's", Cuisine = CuisineType.Italian ,Location = "R.R.Nagar"},
                new Restaurant {Id = 2, Name = "SLV Grand", Cuisine = CuisineType.South_Indian ,Location = "Vijay Nagar"},
                new Restaurant {Id = 3, Name = "Mandara", Cuisine = CuisineType.South_Indian ,Location = "R.R.Nagar"},
                new Restaurant {Id = 4, Name = "Italiano", Cuisine = CuisineType.Italian ,Location = "C.V.Nagar"},
                new Restaurant {Id = 5, Name = "Mexico Spice", Cuisine = CuisineType.Mexican ,Location = "R.R.Nagar"}
                 
            };
        }
        public IEnumerable<Restaurant> GetAllRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
