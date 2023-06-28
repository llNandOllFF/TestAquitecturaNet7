using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Pay.Models
{
    [Table("pago")]
    public class Pago
    {
        [Key,Column("id_operation")] public long IdOperation { get; set; }
        [Column("id_invoice")] public long IdInvoice { get; set; }
        [Column("amount",TypeName ="Decimal(18,6)")] public decimal Amount { get; set;}
        [Column("date")] public DateTime Date { get; set; }
    }
}
