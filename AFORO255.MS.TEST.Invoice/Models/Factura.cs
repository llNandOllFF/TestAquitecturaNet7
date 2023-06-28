using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.Models
{
    [Table("factura",Schema = "factura")]
    public class Factura
    {
        [Key,Column("id_invoice")] public long IdInvoice { get; set; }
        [Column("amount", TypeName ="Decimal(18,6)")] public decimal Amount { get; set; }
        [Column("state")] public int Estado { get; set; }
    }
}
