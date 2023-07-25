using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customSortArray
{
  public class ProductRepositoryBySql:IProductRepository
    {
       public void Add()
        {
            Console.WriteLine("Added by sql");
        }
    }
}
