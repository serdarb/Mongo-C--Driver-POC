using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoSample.Contract;

namespace MongoSample.Web.Models
{
    public class BasketModel
    {
      public  List<BasketItemDto> Items { get; set; }
    }
}