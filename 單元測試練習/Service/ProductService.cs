using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using UnitTestLab1.Factory;
using UnitTestLab1.Repository;

namespace UnitTestLab1
{
    public class ProductService : IProductService
    {
        protected IProductRepository _productRepository;

        public virtual IProductRepository ProductRepositoryObj { set; get; }

        public ProductService()
        {
            _productRepository = RepsotoryFactory.GetProductRepository();
        }
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        //public ProductService()
        //{
        //    _productRepository = new ProductRepository();
        //}

        /// <summary>
        /// 蘋果買2顆 , 香蕉一串 ,芭樂3顆 共多少錢
        /// </summary>
        /// <returns></returns>
        public decimal CulcFruitsPrice(Dictionary<string, int> byFruits)
        {
            
            var fruits = _productRepository.SelectFruits();

            var totalPrice = 0m;
            
           foreach (var keyValue in byFruits)
           {
               var fruit = fruits.FirstOrDefault(p => p.Name == keyValue.Key);
               if (fruit !=null)
               totalPrice += keyValue.Value * fruit.Price;
           }
            

            //foreach (var fruit in fruits)
            //{
            //    if (fruit.Name == "蘋果")
            //        totalPrice += fruit.Price * 2;
            //    else if (fruit.Name == "香蕉")
            //        totalPrice += fruit.Price * 1;
            //    else if (fruit.Name == "芭樂")
            //        totalPrice += fruit.Price * 3;

            //}


            //foreach (DataRow row in dt.Rows)
            //{
            //    if (row["Name"].ToString() == "蘋果")
            //        totalPrice += Convert.ToDecimal(row["Price"]) * 2;
            //    else if (row["Name"].ToString() == "香蕉")
            //        totalPrice += Convert.ToDecimal(row["Price"]) * 1;
            //    else if (row["Name"].ToString() == "芭樂")
            //        totalPrice += Convert.ToDecimal(row["Price"]) * 3;
            //}

            return totalPrice;
        }

        
    }
}