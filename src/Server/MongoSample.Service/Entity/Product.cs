namespace MongoSample.Service.Entity
{
    using MongoDB.Bson;

    public class Product
    {
        public BsonObjectId ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}