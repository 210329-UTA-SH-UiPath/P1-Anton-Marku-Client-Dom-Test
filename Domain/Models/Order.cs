using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; }
        public DateTime? DateTime { get; set; }
        public double? TotalPrice { get; set; }
        public virtual ICollection<OrderPizza> OrderPizzas { get; set; }
    }
}
