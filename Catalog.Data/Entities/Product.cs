using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Data.Entities
{
    public class Product : BaseEntity
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
        [ForeignKey(nameof(Product))]
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Photo
        /// </summary> 
        [ForeignKey(nameof(Upload))]
        public int? UploadId { get; set; }
        public Upload Upload { get; set; }


    }
}
