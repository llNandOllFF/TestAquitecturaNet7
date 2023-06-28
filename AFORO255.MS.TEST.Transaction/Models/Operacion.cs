using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Transaction.Models
{
    public class Operacion
    {
        [BsonId]
        [Column("id_transaccion")]public ObjectId IdTransaccion { get; set; }
        [Column("id_invoice")] public long? IdInvoice { get; set; }
        [Column("amount")] public decimal? Amount { get; set; }
        [Column("data")] public DateTime? Date { get; set; }
    }
}
