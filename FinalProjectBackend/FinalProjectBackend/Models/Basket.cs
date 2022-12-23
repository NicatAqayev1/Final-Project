﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBackend.Models
{
    public class Basket : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Product Product { get; set; }
        public Nullable<int> ColorId { get; set; }
        public Color Color { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Size Size { get; set; }
        public double Price { get; set; }
        public double ExTax { get; set; }
        public int Count { get; set; }
    }
}
