using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixa_bottlestore.Models
{
    using System;

        public class Sale
        {
            public int Id { get; set; }
            public DateTime SaleDate { get; set; }
            public decimal Total { get; set; }
            public string PaymentMethod { get; set; }
            public int UserId { get; set; }
        }
    }


