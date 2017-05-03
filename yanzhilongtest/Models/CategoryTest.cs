using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Domain;
using System.Collections.Generic;
using yanzhilong.Service;

namespace yanzhilongtest
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CategoryCreate()
        {
            CategoryService categoryCRUD = new CategoryService();
            Category category = new Category();
            category.CategoryID = Guid.NewGuid().ToString();
            category.Name = "英文";
            categoryCRUD.Create(category);
    }

        [TestMethod]
        public void CategoryDelete()
        {
            CategoryService categoryCRUD = new CategoryService();
            categoryCRUD.Delete("225c4809-52b1-4884-b383-c15dce2049a2");
        }

        [TestMethod]
        public void CategoryUpdate()
        {
            CategoryService categoryCRUD = new CategoryService();
            Category category = new Category();
            category.CategoryID = "1f1c4189-3792-4a91-8d08-c0d04e18a0a3";
            category.Name = "C#";
            categoryCRUD.Update(category);
        }

        [TestMethod]
        public void GetCategoryById()
        {
            CategoryService categoryCRUD = new CategoryService();
            Category category = categoryCRUD.GetCategoryById("1f1c4189-3792-4a91-8d08-c0d04e18a0a3");
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void GetCategorys()
        {
            CategoryService categoryCRUD = new CategoryService();
            IList<Category> categorys = categoryCRUD.GetCategorys();
            Assert.IsNotNull(categorys);
        }
    }
}
