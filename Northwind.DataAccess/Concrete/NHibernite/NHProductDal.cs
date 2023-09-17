using Entities.Concrete;
using Northwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete.NHibernite
{
    public class NHProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { CategoryId = 5, ProductId = 1, ProductName = "Laptop", QuantityPerUnit = "asdsaf", UnitPrice = 500, UnitsInStock = 50 },
                new Product() { CategoryId = 5, ProductId = 1, ProductName = "Laptop", QuantityPerUnit = "asdsaf", UnitPrice = 500, UnitsInStock = 50 }
            };
            return products;
        }


        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
