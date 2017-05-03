using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Domain;
using System.Collections.Generic;
using yanzhilong.Service;
using yanzhilong.Models;

namespace yanzhilongtest
{
    [TestClass]
    public class ArticleTest
    {
        [TestMethod]
        public void ArticleCreate()
        {
            ArticleService articleCRUD = new ArticleService();
            Article article = new Article();
            article.ArticleID = Guid.NewGuid().ToString();
            article.Title = ".Net MVC学习";
            article.Content = ".Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习,.Net MVC学习";
            article.CreateAt = DateTime.Now;
            article.Disc = "第一次学习好紧张";
            article.Notes = "asd";
            User user = new User();
            user.UserID = "1f1c4189-3792-4a91-8d08-c0d04e18a0ae";
            article.user = user;
            Category category = new Category();
            category.CategoryID = "46ed952b-ec26-4bb9-a544-13a8d78dabf3";
            article.category = category;
            articleCRUD.Create(article);
    }

        [TestMethod]
        public void ArticleDelete()
        {
            ArticleService articleCRUD = new ArticleService();
            articleCRUD.Delete("8a2c21bf-06f9-4e18-8d7f-15299a28c53c");
        }

        [TestMethod]
        public void ArticleUpdate()
        {
            ArticleService articleCRUD = new ArticleService();
            Article article = new Article();
            article.ArticleID = "79a29500-89d5-4bc7-bdfb-6bfbdde32c95";
            article.Title = "爬虫33";
            article.Content = "";
            article.CreateAt = DateTime.Now;
            article.Disc = "Disc";
            article.Notes = "Notes";
            User user = new User();
            user.UserID = "1f1c4189-3792-4a91-8d08-c0d04e18a0ae";
            Category category = new Category();
            category.CategoryID = "1f1c4189-3792-4a91-8d08-c0d04e18a0a3";
            article.user = user;
            article.category = category;
            articleCRUD.Update(article);
        }

        [TestMethod]
        public void GetArticleById()
        {
            ArticleService articleCRUD = new ArticleService();
            Article article = articleCRUD.GetArticleById("79a29500-89d5-4bc7-bdfb-6bfbdde32c95");
            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void GetArticles()
        {
            ArticleService articleCRUD = new ArticleService();
            IList<Article> articles = articleCRUD.GetArticles();
            Assert.IsNotNull(articles);
        }

        [TestMethod]
        public void GetArticlesByPage()
        {
            ArticleService articleCRUD = new ArticleService();
            IList<Article> articles = articleCRUD.GetArticles(1);
            Assert.IsNotNull(articles);
        }

        [TestMethod]
        public void GetStarArticles()
        {
            ArticleService articleCRUD = new ArticleService();
            IList<Article> articles = articleCRUD.GetStarArticles();
            Assert.IsTrue(articles.Count > 0);
        }
    }
}
