using LiteDB;
using personal_finance_maui.Models;

namespace personal_finance_maui.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _liteDatabase;
        private readonly string collectionName = "transactions";
        public TransactionRepository(LiteDatabase liteDatabase)
        {
            _liteDatabase = liteDatabase;
        }

        public List<Transaction> GetAll()
        {
            return _liteDatabase
                     .GetCollection<Transaction>(collectionName)
                     .Query()
                     .OrderByDescending(a => a.Date)
                     .ToList();
        }

        public void Add(Transaction transaction)
        {
            var collection = _liteDatabase.GetCollection<Transaction>(collectionName);
            collection.Insert(transaction);
            collection.EnsureIndex(a => a.Date);
        }

        public void Update(Transaction transaction)
        {
            var collection = _liteDatabase.GetCollection<Transaction>(collectionName);
            collection.Update(transaction);
        }

        public void Delete(Transaction transaction)
        {
            var collection = _liteDatabase.GetCollection<Transaction>(collectionName);
            collection.Delete(transaction.Id);
        }
    }
}
