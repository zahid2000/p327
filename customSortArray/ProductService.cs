using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customSortArray
{
    public class ProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {

            _repository = repository;

        }
       public void Add()
        {
            _repository.Add();
        }
    }
}
