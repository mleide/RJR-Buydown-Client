using System.Collections.Generic;
using System.Data;
using System.Linq;
using CDI.RJR.Data;
using CDI.RJR.Data.Domain;
using RJR.Core;

namespace CDI.RJR.DataConnector
{
    public class DataClient
    {
        readonly Converter _converter;
        readonly BuydownSqlClient _dbClient;

        public DataClient(Converter converter, BuydownSqlClient dbClient)
        {
            _converter = converter;
            _dbClient = dbClient;
        }

        public void SaveProducts(IEnumerable<Product> products)
        {
            var buydownProducts = new List<BuydownProduct>();
            foreach (var p in products)
                buydownProducts.AddRange(_converter.ConvertProduct(p));
        }

        public void SaveLocations(IEnumerable<Outlet> outlets)
        {
            _dbClient.SaveLocations(outlets.Select(_converter.ConvertLocation));
        }

        public void SaveDiscounts(IEnumerable<DiscountRate> discounts)
        {
            _dbClient.SaveDiscounts(discounts.Select(_converter.ConvertDiscount));
        }
    }
}
