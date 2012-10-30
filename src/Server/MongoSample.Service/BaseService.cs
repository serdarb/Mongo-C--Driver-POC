namespace MongoSample.Service
{
    using MongoDB.Driver;
    using MongoSample.Service.Entity;

    public class BaseService
    {
        private MongoDatabase db;
        public MongoDatabase DB
        {
            get
            {
                if (this.db == null)
                {
                    var mongoServer = MongoServer.Create();
                    this.db = mongoServer.GetDatabase("MyMongoDB");
                }

                return this.db;
            }
        }

        private MongoCollection<Product> products;
        public MongoCollection<Product> Products
        {
            get { return this.products ?? (this.products = this.DB.GetCollection<Product>("Product", SafeMode.True)); }
        }

        private MongoCollection<BasketItem> baskets;
        public MongoCollection<BasketItem> Baskets
        {
            get { return this.baskets ?? (this.baskets = this.DB.GetCollection<BasketItem>("Basket", SafeMode.True)); }
        }

        private MongoCollection<BasketHistory> basketHistories;
        public MongoCollection<BasketHistory> BasketHistories
        {
            get { return this.basketHistories ?? (this.basketHistories = this.DB.GetCollection<BasketHistory>("BasketHistory", SafeMode.False)); }
        }

        public void CreateIndexes()
        {
            Baskets.CreateIndex("UserEmail", "AddedOn");
        }
    }
}
