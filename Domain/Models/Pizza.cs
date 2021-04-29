using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBoxApi.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        public int CrustId { get; set; }
        public virtual Crust Crust { get; set; }
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
