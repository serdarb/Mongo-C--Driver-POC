namespace MongoSample.Service
{
    using MongoSample.Contract;
    using MongoSample.Service.Entity;
    using MongoDB.Bson;

    public static class Mappers
    {
        public static BasketItem MapBasketItem(BasketItemDto dto)
        {
            var item = new BasketItem
            {
                Price = dto.Price,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                UserEmail = dto.UserEmail,
                AddedOn = dto.AddedOn
            };

            if (!string.IsNullOrEmpty( dto.Id))
            {
                item.Id = new BsonObjectId(dto.Id);
            }

            return item;
        }

        public static BasketItemDto MapBasketItemDto(BasketItem item)
        {
            return new BasketItemDto
            {
                Id = item.Id.ToString(),
                Price = item.Price,
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Quantity = item.Quantity,
                UserEmail = item.UserEmail,
                AddedOn = item.AddedOn
            };
        }
    }
}
