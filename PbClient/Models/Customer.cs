using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxApi.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? LastTimeOrdered { get; set; }
        public int? StoreId { get; set; }
        public virtual Store Store { get; set; }
        public DateTime? StoreVisitTime { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
