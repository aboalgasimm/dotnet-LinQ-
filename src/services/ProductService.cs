using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductApplication.Models;


namespace ProductApplication.Services;

public class ProductService
{
    private List<Product> _products = new List<Product>();
    public ProductService()
    {
        _products.Add(new Product { Id = 1, Name = "1st Product", Description = "This is the first product.", Price = 111 });
        _products.Add(new Product { Id = 2, Name = "2nd Product", Description = "This is the second product.", Price = 222 });
        _products.Add(new Product { Id = 3, Name = "3rd Product", Description = "This is the third product.", Price = 333 });
    }
     public List<Product> GetProducts()
        {
            return _products;
        }
        
        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
        }
        
        public List<Product> GetProductsOrderedByPrice(bool ascending = true)
        {
            return ascending 
                ? _products.OrderBy(product => product.Price).ToList()
                : _products.OrderByDescending(product => product.Price).ToList();
        }
        
        public List<Product> GetProductByPrice(decimal price)
        {
            var selectedProducts = _products.Where(product => product.Price == price).ToList();
            return selectedProducts;
        }
    }
