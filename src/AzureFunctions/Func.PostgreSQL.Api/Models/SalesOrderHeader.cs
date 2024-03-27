using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("salesorderheader", Schema = "saleslt")]
    public class SalesOrderHeader
    {
        [Key]
        [Column("salesorderid")]
        public int SalesOrderID { get; set; }

        [Required]
        [Column("revisionnumber")]
        public byte RevisionNumber { get; set; }

        [Required]
        [Column("orderdate")]
        public DateTime OrderDate { get; set; }

        [Required]
        [Column("duedate")]
        public DateTime DueDate { get; set; }

        [Column("shipdate")]
        public DateTime? ShipDate { get; set; } = null;

        [Required]
        [Column("status")]
        public byte Status { get; set; }

        [Required]
        [Column("onlineorderflag")]
        public bool OnlineOrderFlag { get; set; }

        [Required]
        [Column("salesordernumber")]
        public string SalesOrderNumber { get; set; }

        [Column("purchaseordernumber")]
        public string PurchaseOrderNumber { get; set; } = null;

        [Column("accountnumber")]
        public string AccountNumber { get; set; } = null;

        [Required]
        [Column("customerid")]
        public int CustomerID { get; set; }

        [Column("shiptoaddressid")]
        public int? ShipToAddressID { get; set; } = null;

        [Column("billtoaddressid")]
        public int? BillToAddressID { get; set; } = null;

        [Required]
        [Column("shipmethod")]
        public string ShipMethod { get; set; }

        [Column("creditcardapprovalcode")]
        public string CreditCardApprovalCode { get; set; } = null;

        [Required]
        [Column("subtotal")]
        public decimal SubTotal { get; set; }

        [Required]
        [Column("taxamt")]
        public decimal TaxAmt { get; set; }

        [Required]
        [Column("freight")]
        public decimal Freight { get; set; }

        [Required]
        [Column("totaldue")]
        public decimal TotalDue { get; set; }

        [Column("comment")]
        public string Comment { get; set; } = null;

        [Required]
        [Column("rowguid")]
        public Guid rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; }
    }
}