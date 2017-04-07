using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Models;
using System.Collections.Generic;

namespace yanzhilongtest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CategoryCreate()
        {
            CategoryCRUD categoryCRUD = new CategoryCRUD();
            Category category = new Category();
            category.CategoryID = Guid.NewGuid().ToString();
            category.Name = "Python";
            Assert.IsTrue(categoryCRUD.Create(category));
    }

        [TestMethod]
        public void CategoryDelete()
        {
            CategoryCRUD categoryCRUD = new CategoryCRUD();
            Assert.IsTrue(categoryCRUD.Delete("225c4809-52b1-4884-b383-c15dce2049a2"));
        }

        [TestMethod]
        public void CategoryUpdate()
        {
            CategoryCRUD categoryCRUD = new CategoryCRUD();
            Category category = new Category();
            category.CategoryID = "1f1c4189-3792-4a91-8d08-c0d04e18a0a3";
            category.Name = "C#";
            Assert.IsTrue(categoryCRUD.Update(category));
        }

        [TestMethod]
        public void GetCategoryById()
        {
            CategoryCRUD categoryCRUD = new CategoryCRUD();
            Category category = categoryCRUD.GetCategoryById("1f1c4189-3792-4a91-8d08-c0d04e18a0a3");
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void GetCategorys()
        {
            CategoryCRUD categoryCRUD = new CategoryCRUD();
            IList<Category> categorys = categoryCRUD.GetCategorys();
            Assert.IsNotNull(categorys);
        }
    }
}
