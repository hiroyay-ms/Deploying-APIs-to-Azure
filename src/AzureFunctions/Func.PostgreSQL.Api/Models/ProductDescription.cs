using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("productdescription", Schema = "saleslt")]
    public class ProductDescription
    {
        [Key]
        [Column("productdescriptionid")]
        public int ProductDescriptionID { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("rowguid")]
        public string rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public string ModifiedDate { get; set; }
    }
}
