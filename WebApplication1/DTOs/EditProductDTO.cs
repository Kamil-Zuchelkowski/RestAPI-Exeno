﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs
{
    public class EditProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.01, 9999.99)]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
