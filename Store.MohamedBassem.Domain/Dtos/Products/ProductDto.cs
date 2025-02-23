﻿using Store.MohamedBassem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.MohamedBassem.Domain.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int? BrandId { get; set; }//FK
        public string BrandName { get; set; }


        public int? TypeId { get; set; }//FK
        public string typeName { get; set; }

    }
}
