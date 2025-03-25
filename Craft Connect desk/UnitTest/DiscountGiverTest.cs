using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models.DiscountSystem;

namespace UnitTest
{
    [TestClass]
    public class DiscountGiverTest
    {
        private IDiscount noDiscount;
        private IDiscount supportingMultipleBussDiscount;
        private IDiscount typeOfItemDiscount;
        private IDiscount customDiscount;

        [TestInitialize]
        public void Setup()
        {
            noDiscount = new NoDiscount();
            supportingMultipleBussDiscount = new SupportingMultipleBussDiscount();
            typeOfItemDiscount = new TypeOfItemDiscount();
            customDiscount = new CustomDiscount();
        }



        [TestMethod]
        [DataRow(DiscountType.NoDiscount)]
        [DataRow(DiscountType.SupportingMultipleBussDiscount)]
        [DataRow(DiscountType.TypeOfItemDiscount)]
        [DataRow(DiscountType.CustomDiscount)]
        public void GetDiscountStrategyTest(DiscountType discountType)
        {
            IDiscount discount;
            //var discountGiver = new DiscountGiver(discountType);
            discount = DiscountFactory.GetDiscountStrategy(discountType);
            switch (discountType)
            {
                case DiscountType.NoDiscount:
                    Assert.IsInstanceOfType(discount, typeof(NoDiscount));
                    break;
                case DiscountType.SupportingMultipleBussDiscount:
                    Assert.IsInstanceOfType(discount, typeof(SupportingMultipleBussDiscount));
                    break;
                case DiscountType.TypeOfItemDiscount:
                    Assert.IsInstanceOfType(discount, typeof(TypeOfItemDiscount));
                    break;
                case DiscountType.CustomDiscount:
                    Assert.IsInstanceOfType(discount, typeof(CustomDiscount));
                    break;
                default:
                    Assert.Fail($"Unhandled discount type: {discountType}");
                    break;
            }
        }

        [TestMethod]
        [DataRow(DiscountType.NoDiscount)]
        [DataRow(DiscountType.SupportingMultipleBussDiscount)]
        [DataRow(DiscountType.TypeOfItemDiscount)]
        [DataRow(DiscountType.CustomDiscount)]
        public void ApplyDiscountTest(DiscountType discountType)
        {
            IDiscount discount;
            var discountGiver = new DiscountGiver(discountType);
            discount = DiscountFactory.GetDiscountStrategy(discountType);
            decimal result = discountGiver.ApplyDiscount(200, 5, 0.15m, 15, 2);

            switch (discountType)
            {
                case DiscountType.NoDiscount:
                    Assert.AreEqual(result, 0);
                    break;
                case DiscountType.SupportingMultipleBussDiscount:
                    Assert.AreEqual(result, 35);
                    break;
                case DiscountType.TypeOfItemDiscount:
                    Assert.AreEqual(result, 5.1m);
                    break;
                case DiscountType.CustomDiscount:
                    Assert.AreEqual(result, 30);
                    break;
                default:
                    Assert.Fail($"Unhandled discount type: {discountType}");
                    break;
            }
        }
    }
}

