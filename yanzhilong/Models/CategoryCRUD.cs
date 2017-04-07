using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class CategoryCRUD
    {
        private SqlMapper sqlMapper = null;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CategoryCRUD()
        {
            ISqlMapper mapper = Mapper.Instance();
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMapper = builder.Configure() as SqlMapper;
        }
        
         
        public bool Create(Category category)
        {
            string connectionString = sqlMapper.DataSource.ConnectionString;
            Console.WriteLine(connectionString);
            try
            {
                sqlMapper.Insert("InsertCategory", category);
                return true;
            }
            catch (Exception e) {
                logger.Error("add Category Fail");
                Console.WriteLine(  e.Message.ToString());
            }
            return false;
        }
         
        public Category GetCategoryById(string categoryID)
        {
            Category category = sqlMapper.QueryForObject<Category>("SelectCategoryById", categoryID);
            
            return category;
        }


        public IList<Category> GetCategorys()
        {
            IList<Category> categorys = sqlMapper.QueryForList<Category>("SelectAllCategory", null);
            return categorys;
        }

        public IList<Category> GetCategorys(int index, int size)
        {
            IList<Category> categoryList = sqlMapper.QueryForList<Category>("SelectAllCategory", null, index, size);
            return categoryList;
        }

        
        public bool Update(Category category)
        {
            int result = sqlMapper.Update("UpdateCategory", category);
            return result > 0;
        }
        

        public bool Delete(string categoryID)
        {
            int result = sqlMapper.Delete("DeleteCategory", categoryID);
            return result > 0;
        }
    }
}