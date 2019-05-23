using System.Collections.Generic;
using System.Data;
using UnitTestLab1.ODT;

namespace UnitTestLab1.Repository
{
    public interface IProductRepository
    {
        List<Product> SelectFruits();
    }
}