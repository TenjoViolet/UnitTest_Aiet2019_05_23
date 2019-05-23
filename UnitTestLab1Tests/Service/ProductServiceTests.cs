using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1Tests.Stub;
using UnitTestLab1.Repository;
using NSubstitute;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        //使用mock的方法要安裝NSubstitute，在單元測試的專案按右鍵，點選「管理NuGet套件」之後，輸入「NSubstitute」按「瀏覽」找「NSubstitute」(這次範例v4.2.0版)安裝
        private IProductRepository _mock = Substitute.For<IProductRepository>();

        [TestMethod()]
        public void CulcFruitsPriceTest_應該Return135()
        {
            //var service = new ProductService();
            
            var service = new ProductService(_mock);
            var expect = 135;
            _mock.SelectFruits().Returns(p => new List<Product>
            {
                 new Product{Name="蘋果",Price=30},
                new Product{Name="香蕉",Price=15},
                new Product{Name="芭樂",Price=20},
            });
            var result = service.CulcFruitsPrice(GetTestFruit());
            Assert.AreEqual(expect, result);
        }



        [TestMethod()]
        public void CulcFruitsPriceTest_應該Return130()
        {
            //var service = new ProductService();
            var service = new ProductService(_mock);
            var expect = 130;
            _mock.SelectFruits().Returns(p => new List<Product>
            {
                 new Product{Name="蘋果",Price=40},
                new Product{Name="香蕉",Price=20},
                new Product{Name="芭樂",Price=10},
            });
            var result = service.CulcFruitsPrice(GetTestFruit());
            Assert.AreEqual(expect, result);
        }

        //[TestMethod()]
        //public void CulcFruitsPriceTest_應該Return135()
        //{
        //    //var service = new ProductService();
        //    var service = new ProductService(new ProductRepositoryStub());
        //    var expect = 135;
        //    var result = service.CulcFruitsPrice(GetTestFruit());
        //    Assert.AreEqual(expect, result);
        //}



        //[TestMethod()]
        //public void CulcFruitsPriceTest_應該Return130()
        //{
        //    //var service = new ProductService();
        //    var service = new ProductService(new ProductRepositoryStub2());
        //    var expect = 130;
        //    var result = service.CulcFruitsPrice(GetTestFruit());
        //    Assert.AreEqual(expect, result);
        //}



        private Dictionary<string, int> GetTestFruit()
        {
            var buyFruitDic = new Dictionary<string, int>();
            buyFruitDic.Add("蘋果", 2);
            buyFruitDic.Add("香蕉", 1);
            buyFruitDic.Add("芭樂", 3);
            return buyFruitDic;
        }

    }

    
}