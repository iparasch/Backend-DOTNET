using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjDAW.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
