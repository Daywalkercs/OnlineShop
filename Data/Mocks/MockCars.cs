using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _carsCategory = new MockCategory();

        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>()
                {
                    new Car()
                    {
                        CarModel = "Honda accord",
                        ShortDescription = "Отличный автомобиль",
                        LongDescription = "",
                        Img = "/img/accord.png",
                        Price = 10000,
                        Available = true,
                        IsFavourite = true,
                        Category = _carsCategory.GetCategories.First()
                    },

                    new Car()
                    {
                        CarModel = "Galant",
                        ShortDescription = "ММММмммм",
                        LongDescription = "",
                        Img = "/img/galant.jpg",
                        Price = 5000,
                        Available = true,
                        IsFavourite = true,
                        Category = _carsCategory.GetCategories.First()
                    },

                    new Car()
                    {
                        CarModel = "Tesla",
                        ShortDescription = "Хня",
                        LongDescription = "",
                        Img = "/img/tesla.jpg",
                        Price = 20000,
                        Available = true,
                        IsFavourite = true,
                        Category = _carsCategory.GetCategories.Last()
                    }
                };
            }
        }
        public required IEnumerable<Car> GetFavCars { get; set; }

        public Car GetCarById(int carID)
        {
            throw new NotImplementedException();
        }

        public void AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(int carId)
        {
            throw new NotImplementedException();
        }


        public void UpdateCar(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
