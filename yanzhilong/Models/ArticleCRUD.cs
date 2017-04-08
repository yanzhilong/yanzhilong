using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class ArticleCRUD
    {
        private SqlMapper sqlMapper = null;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ArticleCRUD()
        {
            ISqlMapper mapper = Mapper.Instance();
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMapper = builder.Configure() as SqlMapper;
        }
        
         
        public bool Create(Article article)
        {
            string connectionString = sqlMapper.DataSource.ConnectionString;
            Console.WriteLine(connectionString);
            try
            {
                sqlMapper.Insert("InsertArticle", article);
                return true;
            }
            catch (Exception e) {
                logger.Error("add Article Fail");
                Console.WriteLine(  e.Message.ToString());
            }
            return false;
        }
         
        public Article GetArticleById(string articleID)
        {
            Article article = sqlMapper.QueryForObject<Article>("SelectArticleById", articleID);
            if(article != null && article.user.UserID != null)
            {
                article.user = sqlMapper.QueryForObject<User>("SelectUserById", article.user.UserID);
            }
            if (article != null && article.category.CategoryID != null)
            {
                article.category = sqlMapper.QueryForObject<Category>("SelectCategoryById", article.category.CategoryID);
            }
            return article;
        }


        public IList<Article> GetArticles()
        {
            IList<Article> articles = sqlMapper.QueryForList<Article>("SelectAllArticle", null);
            return articles;
        }

        public IList<Article> GetArticlesByCategoryId(string categoryID)
        {
            IList<Article> articles = sqlMapper.QueryForList<Article>("SelectArticlesByCategoryId", categoryID);
            return articles;
        }

        

        public IList<Article> GetArticles(int index, int size)
        {
            IList<Article> articleList = sqlMapper.QueryForList<Article>("SelectAllArticle", null, index, size);
            return articleList;
        }

        
        public bool Update(Article article)
        {
            int result = sqlMapper.Update("UpdateArticle", article);
            return result > 0;
        }
        

        public bool Delete(string articleID)
        {
            int result = sqlMapper.Delete("DeleteArticle", articleID);
            return result > 0;
        }
    }
}