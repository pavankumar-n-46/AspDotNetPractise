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
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        int Commit();
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Restaurant> GetAllRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurantOriginal = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurantOriginal != null)
            {
                restaurantOriginal.Name = updatedRestaurant.Name;
                restaurantOriginal.Cuisine = updatedRestaurant.Cuisine;
                restaurantOriginal.Location = updatedRestaurant.Location;
            }
            return restaurantOriginal;
        }
    }
}
