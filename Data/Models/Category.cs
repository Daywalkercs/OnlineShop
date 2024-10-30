using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = "";
        public string? Description { get; set; }

        [JsonIgnore]
        public List<Car>? Cars { get; set; }
    }
}
