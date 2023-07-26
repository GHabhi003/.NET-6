﻿using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract.DTO
{
    public class BuyOrderRequest// : IValidatableObject
    {
        [Required]
        public string StockSymbol { get; set; }

        [Required]
        public string StockName { get; set; }
        
        [Range(typeof(DateTime), "01-01-2000", "01-01-2100")]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000)]
        public uint Quantity { get; set; }

        [Range(1, 10000)]
        public double Price { get; set; }

        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder()
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                Price = Price,
                Quantity = Quantity,
                DateAndTimeOfOrder = DateAndTimeOfOrder
            };
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    List<ValidationResult> results = new List<ValidationResult>();

        //    //Date of order should be less than Jan 01, 2000
        //    if (DateAndTimeOfOrder < Convert.ToDateTime("2000-01-01"))
        //    {
        //        results.Add(new ValidationResult("Date of the order should not be older than Jan 01, 2000."));
        //    }

        //    return results;
        //}
    }
}
