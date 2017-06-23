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
        
        IRepository<Category> repository = new MbRepository<Category>();
        IRepository<ArticleCount> repository1 = new MbRepository<ArticleCount>();

        
        public void Create(Category category)
        {
            repository.Insert("InsertCategory", category);
        }
         
        public Category GetCategoryById(string categoryID)
        {
            Category category = repository.GetByCondition("SelectCategoryByCondition", new Category { Id = categoryID});
            return category;
        }

        public Category GetCategoryByName(string Name)
        {
            Category category = repository.GetByCondition("SelectCategoryByCondition", new Category { Name = Name});
            return category;
        }

        public IList<Category> GetCategorys()
        {
            IList<Category> categorys = repository.GetList("SelectCategoryByCondition", new Category { });
            return categorys;
        }

        public IList<Category> GetCategorys(int pageCount)
        {
            IList<Category> categorys = repository.GetList("SelectCategoryByCondition", new Category { }, pageCount);
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