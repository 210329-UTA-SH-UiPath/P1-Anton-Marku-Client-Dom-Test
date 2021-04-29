using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxApi.Models
{
    public class Size
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Pizza> Pizzas { get; set; }
    }
}
