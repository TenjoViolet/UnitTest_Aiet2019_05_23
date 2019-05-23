using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestLab1.ODT;
using UnitTestLab1.Repository;

namespace UnitTestLab1Tests.Stub
{
    internal class ProductRepositoryStub : IProductRepository
    {
        public List<Product> SelectFruits()
        {
            return new List<Product>
            {
                new Product{Name="蘋果",Price=30},
                new Product{Name="香蕉",Price=15},
                new Product{Name="芭樂",Price=20},
            };
        }
    }


    internal class ProductRepositoryStub2 : IProductRepository
    {
        public List<Product> SelectFruits()
        {
            return new List<Product>
            {
                new Product{Name="蘋果",Price=40},
                new Product{Name="香蕉",Price=20},
                new Product{Name="芭樂",Price=10},
            };
        }
    }
}
