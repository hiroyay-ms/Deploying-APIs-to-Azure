using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("customer", Schema = "saleslt")]
    public class Customer
    {
        [Key]
        [Column("customerid")]
        public int CustomerID { get; set; }

        [Column("title")]
        public string Title { get; set; } = null;

        [Required]
        [Column("firstname")]
        public string FirstName { get; set; }

        [Column("middlename")]
        public string MiddleName { get; set; } = null;

        [Required]
        [Column("lastname")]
        public string LastName { get; set; }

        [Column("suffix")]
        public string Suffix { get; set; } = null;

        [Column("companyname")]
        public string CompanyName { get; set; } = null;

        [Column("salesperson")]
        public string SalesPerson { get; set; } = null;

        [Column("emailaddress")]
        public string EmailAddress { get; set; } = null;

        [Column("phone")]
        public string Phone { get; set; } = null;

        [Required]
        [Column("rowguid")]
        public Guid rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; }
    }
}