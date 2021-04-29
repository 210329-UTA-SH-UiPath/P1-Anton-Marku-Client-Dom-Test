using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxApi.Models
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}
