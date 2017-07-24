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
    public class ArticleService : IBaseService<Article>
    {
        IRepository<Article> repository = new MbRepository<Article>();
        
        public void Create(Article article)
        {
            repository.Insert("InsertArticle", article);
        }
         
        public Article GetArticleById(string articleID)
        {
            Article article = repository.GetByCondition("SelectArticleByCondition", new Article { Id = articleID});
            return article;
        }

        public Article GetPreArticle(Article article)
        {
            Article articlePre = repository.GetByCondition("SelectArticleByPre", new Article { CreateAt = article.CreateAt});
            return articlePre;
        }

        public Article GetNextArticle(Article article)
        {
            Article articleNext = repository.GetByCondition("SelectArticleByNext", new Article { CreateAt = article.CreateAt });
            return articleNext;
        }

        public IList<Article> GetArticles()
        {
            IList<Article> articles = repository.GetList("SelectArticleByCondition", null);
            return articles;
        }

        public IList<Article> GetArticlesByCategoryId(string categoryID)
        {
            IList<Article> articles = repository.GetList("SelectArticleByCondition", new Article { category = new Category { Id = categoryID } });
            return articles;
        }

        public IList<Article> GetArticles(int pageCount,string categoryID)
        {
            IList<Article> articles = repository.GetList("SelectArticleByCondition", new Article { category = new Category { Id = categoryID } },pageCount);
            return articles;
        }

        public IList<Article> GetArticles(int pageCount)
        {
            IList<Article> articleList = repository.GetList("SelectArticleByCondition", new Article { }, pageCount);
            return articleList;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectArticleCount", null);
            return count;            
        }

        public int GetCount(string categoryID)
        {
            int count = repository.GetObject<int>("SelectArticleCount", new Article { category = new Category { Id = categoryID } });
            return count;
        }


        public IList<Article> GetStarArticles()
        {
            IList<Article> articles = repository.GetList("SelectArticleByStar", ResourceType.ARTICLE);
            return articles;
        }

        public void Update(Article article)
        {
            repository.Update("UpdateArticle", article);
        }

        public void Delete(string articleID)
        {
            repository.Delete("DeleteArticle", new Article { Id = articleID});
        }

        public void AddEntry(Article entry)
        {
            throw new NotImplementedException();
        }

        public void AddEntrys(IList<Article> entrys)
        {
            repository.Insert("InsertArticle", entrys);
        }

        public void DeleteEntry(Article entry)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntrys(IList<Article> entrys)
        {
            repository.Delete("DeleteArticle", entrys);
        }

        public void UpdateEntry(Article entry)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntrys(IList<Article> entrys)
        {
            repository.Update("UpdateArticle", entrys);
        }

        public IEnumerable<Article> GetEntrys(Article entry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetEntrys(Article entry, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetEntrys(int skip, int take, Article entry)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public Article GetEntry(Article entry)
        {
            throw new NotImplementedException();
        }

        public Article GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Article entry)
        {
            throw new NotImplementedException();
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }
    }
}