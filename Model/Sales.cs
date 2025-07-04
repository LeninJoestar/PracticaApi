using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad2_BD_API.Model
{
    [Table("Customer", Schema = "Sales")]
    public class Sales
    {
        [Key]

        public required int CustomerID{ get;set; }

        public required int? PersonID { get; set; }

        public required int? StoreID { get; set; }

        public required int? TerritoryID { get; set; }

        public required string AccountNumber { get; set; }

        public required Guid rowguide { get; set; }

        public required DateTime ModifiedDate { get; set; }

    }
}
