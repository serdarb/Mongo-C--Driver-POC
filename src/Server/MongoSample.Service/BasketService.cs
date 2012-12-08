namespace MongoSample.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MongoDB.Bson;
    using MongoDB.Driver.Builders;
    using MongoSample.Contract;
    using MongoSample.Service.Entity;

    public class BasketService : BaseService, IBasketService
    {
        public bool Add(BasketItemDto dto)
        {
            return Baskets.Insert<BasketItem>(Mappers.MapBasketItem(dto)).Ok;
        }

        public bool Remove(BasketItemDto dto)
        {
            return Baskets.Remove(Query<BasketItem>.EQ(x => x.Id, new BsonObjectId(dto.Id))).Ok;
        }

        public bool Update(BasketItemDto dto)
        {
            return Baskets.Save<BasketItem>(Mappers.MapBasketItem(dto)).Ok;
        }

        public List<BasketItemDto> Get(string email)
        {
            var items = Baskets.FindAs<BasketItem>(Query<BasketItem>.EQ(x => x.UserEmail, email));

            var result = new List<BasketItemDto>();
            foreach (var item in items)
            {
                result.Add(Mappers.MapBasketItemDto(item));
            }

            return result;
        }

        public bool Clear(string email)
        {
            return Baskets.Remove(Query<BasketItem>.EQ(x => x.UserEmail, email)).Ok;
        }
        
        public double MapReduceCount()
        {
            const string map = @"
                        function() {
                            emit(this.Id, {count:1});
                        }";

            const string reduce = @"        
                            function(key, values) {
                                var result = { count: 0 };

                                values.forEach(function(value){               
                                    result.count += value.count;
                                });

                                return result;
                            }";

            var results = Baskets.MapReduce(map,
                                            reduce,
                                            MapReduceOptions.SetOutput(MapReduceOutput.Inline))
                                            .GetResults();

            return results.First().Elements.Last().Value.AsBsonDocument.GetValue("count").AsDouble;
        }

        public double MapReduceSum()
        {
            const string map = @"
                        function() {
                            emit(this.Price, { totalPrice: this.Price });
                        }";

            const string reduce = @"        
                            function(key, values) {
                                var result = { totalPrice: 0 };

                                values.forEach(function(value){               
                                    result.totalPrice += parseFloat(value.totalPrice);
                                });

                                return result;
                            }";

            var results = Baskets.MapReduce(map,
                                            reduce,
                                            MapReduceOptions.SetOutput(MapReduceOutput.Inline))
                                            .GetResults();
            
           return results.First().Elements.Last().Value.AsBsonDocument.GetValue("totalPrice").AsDouble;
        }
    }
}
