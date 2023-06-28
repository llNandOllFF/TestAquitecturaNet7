using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Persistencia
{
    public interface IMongoBookDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
