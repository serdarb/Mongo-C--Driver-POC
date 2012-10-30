namespace MongoSample.Service.Entity
{
    using MongoDB.Bson;
    using System;

    public class BasketItem
    {
        public BsonObjectId Id { get; set; }
        public string UserEmail { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime AddedOn { get; set; }
    }
}