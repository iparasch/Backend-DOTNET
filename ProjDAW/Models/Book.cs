using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjDAW.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public int Quantity { get; set; }
        public DateTime Aparition { get; set; }

    }
}
