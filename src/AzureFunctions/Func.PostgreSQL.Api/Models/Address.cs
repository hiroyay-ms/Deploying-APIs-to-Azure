using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Func.PostgreSQL.Api.Models
{
    [Table("address", Schema = "saleslt")]
    public class Address
    {
        [Key]
        [Column("addressid")]
        public int AddressID { get; set; }

        [Required]
        [Column("addressline1")]
        public string AddressLine1 { get; set; }

        [Column("addressline2")]
        public string AddressLine2 { get; set; } = null;

        [Required]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [Column("stateprovince")]
        public string StateProvince { get; set; }

        [Required]
        [Column("countryregion")]
        public string CountryRegion { get; set; }

        [Required]
        [Column("postalcode")]
        public string PostalCode { get; set; }

        [Required]
        [Column("rowguid")]
        public Guid rowguid { get; set; }

        [Required]
        [Column("modifieddate")]
        public DateTime ModifiedDate { get; set; }
    }
}