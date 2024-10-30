using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class DbObjects
    {
        private static Dictionary<string, Category>? _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var listOfCategory = new Category[]
                    {
                        new Category { CategoryName = "Electro Cars", Description = "Need charge!"},
                        new Category { CategoryName = "Gas Cars", Description = "Need gas!"}
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (var category in listOfCategory)
                        _categories.Add(category.CategoryName, category);

                }
                return _categories;
            }
        }

        public static void Initial(ApplicationDbContext appContext)
        {

            if (!appContext.Category.Any())
                appContext.Category.AddRange(Categories.Select(c => c.Value));

            //if (!appContext.Car.Any())
            //{

            var listOrCars = new List<Car>
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
                    Category = Categories["Gas Cars"]
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
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "Tesla",
                    ShortDescription = "Хня",
                    LongDescription = "",
                    Img = "/img/tesla.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Electro Cars"]
                },

                new Car()
                {
                    CarModel = "AstonMartin",
                    ShortDescription = "Bond",
                    LongDescription = "",
                    Img = "/img/AstonMartinDB12.webp",
                    Price = 20000,
                    Available = true,
                    IsFavourite = true,
                    Category = Categories["Gas Cars"]
                },
                new Car()
                {
                    CarModel = "AudiA6",
                    ShortDescription = "Перевозчик",
                    LongDescription = "",
                    Img = "/img/AudiA6.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "BMW5",
                    ShortDescription = "Перевозчик",
                    LongDescription = "",
                    Img = "/img/BMW5.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "ChevroletCamaro",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/ChevroletCamaro.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = true,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "DodgeChallenger",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/DodgeChallenger.webp",
                    Price = 20000,
                    Available = true,
                    IsFavourite = true,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "FerrariF12BERLINETTA",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/FerrariF12BERLINETTA.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = true,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "FordMustang",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/FordMustang.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = true,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "Lexus LC 500",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/Lexus LC 500.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "Mazda6",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/Mazda6.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "Nissan370Z",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/Nissan370Z.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "VolkswagenPolo",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/VolkswagenPolo.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Gas Cars"]
                },

                new Car()
                {
                    CarModel = "Мерседес AMG",
                    ShortDescription = "ShortDescription",
                    LongDescription = "",
                    Img = "/img/Мерседес AMG.jpg",
                    Price = 20000,
                    Available = true,
                    IsFavourite = false,
                    Category = Categories["Gas Cars"]
                }


            };

            foreach (var item in listOrCars)
            {
                var existingCar = appContext.Car.FirstOrDefault(c => c.CarModel == item.CarModel);
                if (existingCar == null) appContext.Add(item);
                else
                {
                    existingCar.ShortDescription = item.ShortDescription;
                    existingCar.LongDescription = item.LongDescription;
                    existingCar.Img = item.Img;
                    existingCar.Price = item.Price;
                    existingCar.Available = item.Available;
                    existingCar.IsFavourite = item.IsFavourite;
                    existingCar.Category = item.Category;
                }
    
            }

            appContext.SaveChanges();
        }

    }
}
