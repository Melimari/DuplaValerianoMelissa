using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_bottlestore.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Code { get; set; }   
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int LowStockThreshold { get; set; }
        public bool Active { get; set; }
    }

}
