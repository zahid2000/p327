using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customSortArray
{
    internal class ProductRepositoryByOracle : IProductRepository
    {
        public void Add()
        {
            Console.WriteLine("Added by Oracle");
        }
    }
}
