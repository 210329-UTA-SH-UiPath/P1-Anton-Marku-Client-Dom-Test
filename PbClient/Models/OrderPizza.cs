using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxApi.Models
{
    public class OrderPizza
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int PizzaId { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
