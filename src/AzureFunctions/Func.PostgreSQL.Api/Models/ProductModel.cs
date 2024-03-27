using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("productmodel", Schema = "saleslt")]
    public class ProductModel
    {
        [Key]
        [Column("productmodelid")]
        public int ProductModelID { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("catalogdescription")]
        public string CatalogDescription { get; set; } = null;

        [Required]
        [Column("rowguid")]
        public Guid rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; }
    }
}
