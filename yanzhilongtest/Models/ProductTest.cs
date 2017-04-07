using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Models;
using System.Collections.Generic;

namespace yanzhilongtest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductCreate()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            Product product = new Product();
            product.ProductID = Guid.NewGuid().ToString();
            product.Name = "搜鞋网数据包生成软件";
            product.Content = "软件采用多线程方式从搜鞋网上抓取鞋子的数据(一个小时可达上千款)，并生成淘宝助理的数据包，方便上传宝贝";
            product.Size = 650;
            product.Version = "V1.0";
            product.Disc = "自动获取搜鞋网图片，下载数据包，搜鞋网自动上图到淘宝";
            product.Notes = "自动从搜鞋网下载鞋子的数据，并生成淘宝的数据包.";
            product.CreateAt = DateTime.Now;
            Assert.IsTrue(productCRUD.Create(product));
        }

        [TestMethod]
        public void ProductDelete()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            Assert.IsTrue(productCRUD.Delete("87321164-5315-44a1-96f2-c0fd4a9b9159"));
        }
        
        [TestMethod]
        public void ProductUpdate()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            Product product = new Product();
            product.ProductID = "6729ee23-6d46-4efe-a4ce-b015c7394aa4";
            product.Name = "爬虫12";
            product.Size = 500;
            product.Version = "V1.0";
            product.Notes = "asd";
            product.CreateAt = DateTime.Now;
            Assert.IsTrue(productCRUD.Update(product));
        }

        [TestMethod]
        public void GetProductById()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            Product product = productCRUD.GetProductById("6729ee23-6d46-4efe-a4ce-b015c7394aa4");
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void GetProducts()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            IList<Product> products = productCRUD.GetProducts();
            Assert.IsNotNull(products);
        }
    }
}
