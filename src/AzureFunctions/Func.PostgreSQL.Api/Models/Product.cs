using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
        [Table("product", Schema = "saleslt")]
        public class Product
        {
            [Key]
            [Column("productid")]
            public int ProductID { get; set; }

            [Required]
            [Column("name")]
            public string Name { get; set; }

            [Required]
            [Column("productnumber")]
            public string ProductNumber { get; set; }

            [Column("color")]
            public string Color { get; set; }

            [Required]
            [Column("standardcost")]
            public decimal StandardCost { get; set; }

            [Required]
            [Column("listprice")]
            public decimal ListPrice { get; set; }

            [Column("size")]
            public string Size { get; set; }

            [Column("weight")]
            public decimal? Weight { get; set; } = null;

            [Column("productcategoryid")]
            public int? ProductCategoryID { get; set; } = null;

            [Column("productmodelid")]
            public int? ProductModelID { get; set; } = null;

            [Required]
            [Column("sellstartdate")]
            public DateTime SellStartDate { get; set; }

            [Column("sellenddate")]
            public DateTime? SellEndDate { get; set; }

            [Column("discontinueddate")]
            public DateTime? DiscontinuedDate { get; set; }

            [Column("thumbnailphotofilename")]
            public string ThumbnailPhotoFileName { get; set; }

            [Required]
            [Column("rowguid")]
            public Guid rowguid { get; set; }

            [Required]
            [Column("modifieddate")]
            public DateTime ModifiedDate { get; set; }
        }
}