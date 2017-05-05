using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Models;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class ProductService
    {
        IRepository<Product> repository = new MbRepository<Product>();
        public void Create(Product product)
        {
            repository.Insert("InsertProduct", product);
        }
         
        public Product GetProductById(string productID)
        {
            Product product = repository.GetByCondition("SelectProductByCondition", new Product { ProductID = productID});
            return product;
        }

        public IList<Product> GetProducts()
        {
            IList<Product> products = repository.GetList("SelectProductByCondition", null);
            return products;
        }

        public IList<Product> GetStarProducts()
        {
            IList<Product> products = repository.GetList("SelectProductByStar", ResourceType.PRODUCT);
            return products;
        }

        public IList<Product> GetProducts(int pageCount)
        {
            IList<Product> productList = repository.GetList("SelectProductByCondition", new Product { }, pageCount);
            return productList;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelecProductCount", null);
            return count;
        }

        public void Update(Product product)
        {
            repository.Update("UpdateProduct", product);
        }
        
        public void Delete(string productID)
        {
            repository.Delete("DeleteProduct", productID);
        }
    }
}