using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductAPI.Models;

namespace ProductAPI.Service
{
    public class ProductService
    {
        private readonly List<Products> productsContainer = new List<Products>();

        public async Task<Products?> AddAsync(Products product)
        {
            product.Id = Guid.NewGuid();
            productsContainer.Add(product);
            return await Task.FromResult(product);
        }

        public async Task<Products?> DeleteAsync(Guid id)
        {
            var existingProduct = productsContainer.Find(x => x.Id == id);

            if (existingProduct != null)
            {
                productsContainer.Remove(existingProduct);
            }

            return await Task.FromResult(existingProduct);
        }

        public async Task<IEnumerable<Products>> GetAllAsync()
        {
            return await Task.FromResult(productsContainer);
        }

        public async Task<Products?> GetAsync(Guid id)
        {
            return await Task.FromResult(productsContainer.Find(x => x.Id == id));
        }

        public async Task<Products?> UpdateAsync(Products product)
        {
            var existingProduct = productsContainer.Find(x => x.Id == product.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Category = product.Category;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Price = product.Price;
                existingProduct.Discount = product.Discount;
                existingProduct.Specification = product.Specification;

                return await Task.FromResult(existingProduct);
            }

            return await Task.FromResult<Products?>(null);
        }
    }
}






























































//using ProductAPI.Models;

//namespace ProductAPI.Service

//{
//    public class ProductService

//    {
//        public List<Products> productsContainer = new List<Products>();
//        public  async Task<Products> AddAsync(Products product)
//        {
//            product.Id = Guid.NewGuid();
//            productsContainer.Add(product);
//            return product;
//        }

//        public async Task<Products> DeleteAsync(Guid id)
//        {
//            var existingProduct = productsContainer.Find(x => x.Id == id);

//            productsContainer.Remove(existingProduct);

//            return existingProduct;
//        }

//        public async Task<IEnumerable<Products>> GetAllAsync()
//        {
//            return productsContainer;
//        }

//        public async Task<Products> GetAsync(Guid id)
//        {
//            return productsContainer.Find(x => x.Id == id);
//        }

//        public async Task<Products> UpdateAsync(Products product)
//        {

//            var existingProduct = productsContainer.Find(x => x.Id == product.Id);

//            if (existingProduct != null)
//            {
//                existingProduct.Name = product.Name;
//                existingProduct.Description = product.Description;
//                existingProduct.Category = product.Category;
//                existingProduct.Quantity = product.Quantity;
//                existingProduct.Price = product.Price;
//                existingProduct.Discount = product.Discount;
//                existingProduct.Specification = product.Specification;

//                return product;
//            }

//            return null;
//        }

//    }
//}
