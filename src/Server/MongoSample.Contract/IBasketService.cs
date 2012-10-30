namespace MongoSample.Contract
{
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface IBasketService
    {
        [OperationContract]
        bool Add(BasketItemDto dto);
        [OperationContract]
        bool Remove(BasketItemDto dto);
        [OperationContract]
        bool Update(BasketItemDto dto);
        [OperationContract]
        List<BasketItemDto> Get(string email);
        [OperationContract]
        bool Clear(string email);
    }
}
