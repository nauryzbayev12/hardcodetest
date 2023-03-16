﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Data.Entities
{
    public class ProductType : BaseEntity
    {
        /// <summary>
        /// Name of category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Whether products in this category have a size
        /// </summary>
        public bool HaveSize { get; set; }

        /// <summary>
        /// Whether products in this category have a color
        /// </summary>
        public bool HaveColor { get; set; }


        /// <summary>
        /// Whether products in this category have a Weight
        /// </summary>
        public bool HaveWeight { get; set; }

    }
}
