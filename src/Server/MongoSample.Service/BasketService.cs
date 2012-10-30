namespace MongoSample.Service
{
    using System.Collections.Generic;
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
    }
}
