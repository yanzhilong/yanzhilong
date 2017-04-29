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
    public class CategoryService
    {
        //private SqlMapper sqlMapper = null;
        //readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //public CategoryService()
        //{
        //    ISqlMapper mapper = Mapper.Instance();
        //    DomSqlMapBuilder builder = new DomSqlMapBuilder();
        //    sqlMapper = builder.Configure() as SqlMapper;
        //}

        IRepository<Category> repository = new MbRepository<Category>();
        IRepository<ArticleCount> repository1 = new MbRepository<ArticleCount>();

        
        public void Create(Category category)
        {
            repository.Insert("InsertCategory", category);
        }
         
        public Category GetCategoryById(string categoryID)
        {
            Category category = repository.GetByCondition("SelectCategoryById", categoryID);
            return category;
        }

        public Category GetCategoryByName(string Name)
        {
            Category category = repository.GetByCondition("SelectCategoryByName", Name);
            return category;
        }

        public IList<Category> GetCategorys()
        {
            IList<Category> categorys = repository.GetList("SelectAllCategory", null);
            return categorys;
        }

        public IList<Category> GetCategorys(int pageCount)
        {
            IList<Category> categorys = repository.GetList("SelectAllCategory", null, pageCount);
            return categorys;
        }

        public IList<ArticleCount> GetArticlesCountGroupByCategory()
        {
            IList<ArticleCount> articlecounts = repository1.GetList("SelectArticlesNumGroupByCategory", null);
            return articlecounts;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelectCategoryCount", null);
            return count;
        }

        public void Update(Category category)
        {
            repository.Update("UpdateCategory", category);
        }

        public void Delete(string categoryID)
        {
            repository.Delete("DeleteCategory", categoryID);
        }
    }
}