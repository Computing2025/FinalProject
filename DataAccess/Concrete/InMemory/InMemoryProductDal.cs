using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new()
            {
                new Product{ProductId=1, CategoryId=1, UnitsInStock=15, ProductName="Bardak", UnitPrice=15},
                new Product{ProductId=2, CategoryId=1, UnitsInStock=3, ProductName="Kamera", UnitPrice=500},
                new Product{ProductId=3, CategoryId=2, UnitsInStock=2, ProductName="Telefon", UnitPrice=1500},
                new Product{ProductId=4, CategoryId=2, UnitsInStock=65, ProductName="Klavye", UnitPrice=150},
                new Product{ProductId=5, CategoryId=2, UnitsInStock=1, ProductName="Fare", UnitPrice=85}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product); 
        }

        public void Delete(Product product)
        {
            Product? productToDelete = _products.SingleOrDefault(
                p => p.ProductId == product.ProductId
            );
                _products.Remove(productToDelete!);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null!)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product? productToUpdate = _products.FirstOrDefault( 
                p => p.ProductId == product.ProductId 
            );
            productToUpdate!.ProductName = product.ProductName;
            productToUpdate!.UnitPrice = product.UnitPrice;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}


