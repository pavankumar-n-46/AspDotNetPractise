using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;


namespace OdeToFood.data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int Id);
        int Commit();
    }
}
