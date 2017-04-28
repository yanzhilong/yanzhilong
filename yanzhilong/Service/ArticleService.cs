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
    public class ArticleService
    {
        IRepository<Article> repository = new MbRepository<Article>();
        
        public void Create(Article article)
        {
            repository.Insert("InsertArticle", article);
        }
         
        public Article GetArticleById(string articleID)
        {
            Article article = repository.GetByCondition("SelectArticleById", articleID);
            return article;
        }

        public Article GetPreArticle(Article article)
        {
            Article articlePre = repository.GetByCondition("SelectArticleByPre", article);
            return articlePre;
        }

        public Article GetNextArticle(Article article)
        {
            Article articleNext = repository.GetByCondition("SelectArticleByNext", article);
            return articleNext;
        }


        public IList<Article> GetArticles()
        {
            IList<Article> articles = repository.GetList("SelectAllArticle", null);
            return articles;
        }

        public IList<Article> GetArticlesByCategoryId(string categoryID)
        {
            IList<Article> articles = repository.GetList("SelectArticlesByCategoryId", categoryID);
            return articles;
        }

        public IList<Article> GetArticles(int pageCount,string categoryID)
        {
            IList<Article> articleList = null;
            if (categoryID != null)
            {
                articleList = repository.GetList("SelectArticlesContainUserByCategoryId", categoryID,pageCount);
            }
            else
            {
                articleList = repository.GetList("SelectAllArticleContainUser", null, pageCount);
            }
            return articleList;
        }

        public IList<Article> GetArticles(int pageCount)
        {
            IList<Article> articleList = repository.GetList("SelectArticlesContainUserByCategoryId",null, pageCount);
            return articleList;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectArticleCount", null);
            return count;            
        }

        public int GetCount(string categoryID)
        {
            if(categoryID == null)
            {
                return GetCount();
            }
            int count = repository.GetObject<int>("SelectArticleCount", categoryID);
            return count;
        }


        public IList<Article> GetStarArticles()
        {
            IList<Article> articles = repository.GetList("SelectStarArticle", ResourceType.ARTICLE);
            return articles;
        }

        public void Update(Article article)
        {
            repository.Update("UpdateArticle", article);
        }
        

        public void Delete(string articleID)
        {
            repository.Delete("DeleteArticle", articleID);
        }
    }
}