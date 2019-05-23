using System.Collections.Generic;
using UnitTestLab1.Repository;

namespace UnitTestLab1
{
    public interface IProductService
    {
        IProductRepository ProductRepositoryObj { get; set; }

        decimal CulcFruitsPrice(Dictionary<string, int> byFruits);
    }
}