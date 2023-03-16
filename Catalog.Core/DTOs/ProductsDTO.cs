using Catalog.Data.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Core.DTOs
{

    public class CreateProductDTO
    {
        /// <summary>
        /// Name of product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of product
        /// </summary>
        public string Description { get; set; }

        /// <summary> 
        /// Cost of product
        /// </summary> 
        public double? Cost { get; set; }

        /// <summary>
        /// Unit : m3
        /// </summary>
        public double? Size { get; set; }

        /// <summary>
        /// Color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Unit : Kg
        /// </summary>
        public double? Weight { get; set; }

        /// <summary>
        /// Product Type
        /// </summary> 
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// Фото
        /// </summary>
        public IFormFile Photo { get; set; } 
    }
    public class UpdateProductDTO : CreateProductDTO
    {

        /// <summary>
        /// Primary Key
        /// </summary>
        public int Id { get; set; }
    }

    public class ProductDTO : CreateProductDTO
    {
      
    }
}
