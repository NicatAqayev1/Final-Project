﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBackend.Models;

namespace FinalProjectBackend.ViewModels.Basket
{
    public class BasketVM
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int StockCount { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ColorId { get; set; }
        public string ColorName { get; set; }
        public Nullable<int> SizeId { get; set; }
        public string SizeName { get; set; }
        public double ExTax { get; set; }
    }
}
