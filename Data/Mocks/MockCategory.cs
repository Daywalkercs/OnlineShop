using OnlineShop.Data.Interfaces;
using OnlineShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> GetCategories
        {
            get
            {
                return new List<Category>()
                {
                    new Category { CategoryName = "Electro Cars", Description = "Need charge!"},
                    new Category { CategoryName = "Gas Cars", Description = "Need gas!"}
                };
            }
        }
    }
}
