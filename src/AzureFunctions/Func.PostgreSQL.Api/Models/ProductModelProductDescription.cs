using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("productmodelproductdescription", Schema = "saleslt")]
    public class ProductModelProductDescription
    {
        [Key]
        [Column("productmodelid")]
        public int ProductModelID { get; set; }

        [Key]
        [Column("productdescriptionid")]
        public int ProductDescriptionID { get; set; }

        [Required]
        [Column("culture")]
        public string Culture { get; set; }

        [Required]
        [Column("rowguid")]
        public string rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public string ModifiedDate { get; set; }
    }
}
