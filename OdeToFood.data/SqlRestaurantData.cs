using System.Collections.Generic;
using OdeToFood.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            dbContext.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public Restaurant Delete(int Id)
        {
            var restaurantDelete = GetRestaurantById(Id);
            if (restaurantDelete != null)
            {
                dbContext.Remove(restaurantDelete);
            }
            return restaurantDelete;
        }

        public IEnumerable<Restaurant> GetAllRestaurantsByName(string name)
        {
            return from r in dbContext.Restaurants
                   where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return dbContext.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }
    }
}
