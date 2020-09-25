using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace realpage.Domain.Entities
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? UnitsInStock { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
