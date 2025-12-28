using LiteDB;

namespace personal_finance_maui.Models
{
    public class Transaction
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Value { get; set; }
        public TransactionType Type { get; set; }
    }

    public enum TransactionType
    {
        Income,
        Expanse
    }
}
