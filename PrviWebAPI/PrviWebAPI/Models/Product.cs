using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrviWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public String Kategorija { get; set; }
        public decimal Cena { get; set; }
    }
}