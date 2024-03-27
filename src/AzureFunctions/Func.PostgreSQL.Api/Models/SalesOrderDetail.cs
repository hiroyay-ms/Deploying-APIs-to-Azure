using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("salesorderdetail", Schema = "saleslt")]
    public class SalesOrderDetail
    {
        [Required]
        [Column("salesorderid")]
        public int SalesOrderID { get; set; }

        [Key]
        [Column("salesorderdetailid")]
        public int SalesOrderDetailID { get; set; }

        [Required]
        [Column("orderqty")]
        public Int16 OrderQty { get; set; }

        [Required]
        [Column("productid")]
        public int ProductID { get; set; }

        [Required]
        [Column("unitprice")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Column("unitpricediscount")]
        public decimal UnitPriceDiscount { get; set; }

        [Required]
        [Column("linetotal")]
        public decimal LineTotal { get; set; }

        [Required]
        [Column("rowguid")]
        public Guid rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; }
    }
}