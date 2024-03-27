using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("productcategory", Schema = "saleslt")]
    public class ProductCategory
    {
        [Key]
        [Column("productcategoryid")]
        public int ProductCategoryID { get; set; }

        [Column("parentproductcategoryid")]
        public int? ParentProductCategoryID { get; set; } = null;

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("rowguid")]
        public Guid rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; }
    }
}