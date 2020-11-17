﻿using System.ComponentModel.DataAnnotations;

namespace ApiRestfulSample.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int TotalQuantity { get; set; }
    }
}
