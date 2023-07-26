using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.DTO
{
    public class SellOrderRequest
    {
        [Required]
        public string StockSymbol { get; set; }

        [Required]
        public string StockName { get; set; }

        [Range(typeof(DateTime), "01/01/2000", "01/01/2100")]
        DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000)]
        uint Quantity { get; set; }

        [Range(1, 10000)]
        double Price { get; set; }

        public SellOrder ToSellOrder()
        {
            return new SellOrder()
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                Price = Price,
                Quantity = Quantity,
                DateAndTimeOfOrder = DateAndTimeOfOrder
            };
        }
    }
}
