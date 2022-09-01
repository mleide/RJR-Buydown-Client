using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CDI.RJR.Data.Domain;

namespace CDI.RJR.Data
{
    public class BuydownSqlClient
    {
        readonly BuydownAllowanceDataAccess _allowance;
        readonly BuydownDiscountDataAccess _discount;
        readonly BuydownLocationDataAccess _location;
        readonly BuydownPeriodDataAccess _period;
        readonly BuydownProductDataAccess _product;
        readonly BuydownProgramDataAccess _program;

        public BuydownSqlClient(string connectionString)
        {
            var database = new Database(connectionString);
            _allowance = new BuydownAllowanceDataAccess(database);
            _discount = new BuydownDiscountDataAccess(database);
            _location = new BuydownLocationDataAccess(database);
            _period = new BuydownPeriodDataAccess(database);
            _product = new BuydownProductDataAccess(database);
            _program = new BuydownProgramDataAccess(database);
        }

        public void SaveAllowances(IEnumerable<BuydownAllowance> allowances)
        {
            foreach (var allowance in allowances)
                SaveAllowance(allowance);
        }

        public void SaveAllowance(BuydownAllowance allowance) =>
            allowance.Id = _allowance.Insert(allowance);
        
        public void SaveDiscounts(IEnumerable<BuydownDiscount> discounts)
        {
            foreach (var discount in discounts)
                SaveDiscount(discount);
        }

        public void SaveDiscount(BuydownDiscount discount) =>
            discount.Id = _discount.Insert(discount);

        public void SaveLocations(IEnumerable<BuydownLocation> locations)
        {
            foreach (var location in locations)
                SaveLocation(location);
        }

        public void SaveLocation(BuydownLocation location) =>
            location.Id = _location.Insert(location);

        public void SavePeriods(IEnumerable<BuydownPeriod> periods)
        {
            foreach (var period in periods)
                SavePeriod(period);
        }

        public void SavePeriod(BuydownPeriod period) =>
            period.Id = _period.Insert(period);

        public void SaveProducts(IEnumerable<BuydownProduct> products)
        {
            foreach (var product in products)
                SaveProduct(product);
        }

        public void SaveProduct(BuydownProduct product) =>
            product.Id = _product.Insert(product);

        public void SavePrograms(IEnumerable<BuydownProgram> programs)
        {
            foreach (var program in programs)
                SaveProgram(program);
        }

        public void SaveProgram(BuydownProgram program) =>
            program.Id = _program.Insert(program);
    }
}
