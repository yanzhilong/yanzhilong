using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Models;

namespace yanzhilong.Models
{
    public class ResourceStarCRUD
    {
        private SqlMapper sqlMapper = null;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ResourceStarCRUD()
        {
            ISqlMapper mapper = Mapper.Instance();
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            sqlMapper = builder.Configure() as SqlMapper;
        }
        
         
        public bool Create(ResourceStar resourceStar)
        {
            string connectionString = sqlMapper.DataSource.ConnectionString;
            Console.WriteLine(connectionString);
            try
            {
                sqlMapper.Insert("InsertResourceStar", resourceStar);
                return true;
            }
            catch (Exception e) {
                logger.Error("add ResourceStar Fail");
                Console.WriteLine(  e.Message.ToString());
            }
            return false;
        }
         
        public ResourceStar GetResourceStarById(string resourceStarID)
        {
            ResourceStar resourceStar = sqlMapper.QueryForObject<ResourceStar>("SelectResourceStarById", resourceStarID);
            
            return resourceStar;
        }


        public IList<ResourceStar> GetResourceStars()
        {
            IList<ResourceStar> resourceStars = sqlMapper.QueryForList<ResourceStar>("SelectAllResourceStar", null);
            return resourceStars;
        }

        public IList<ResourceStar> GeResourceStarByType(int resourceTypeID)
        {
            IList<ResourceStar> resourceStars = sqlMapper.QueryForList<ResourceStar>("SelectAllResourceStarByType", resourceTypeID);
            return resourceStars;
        }

        public IList<ResourceStar> GeResourceStars(int index, int size)
        {
            IList<ResourceStar> resourceStarList = sqlMapper.QueryForList<ResourceStar>("SelectAllResourceStar", null, index, size);
            return resourceStarList;
        }

        
        public bool Update(ResourceStar resourceStar)
        {
            int result = sqlMapper.Update("UpdateResourceStar", resourceStar);
            return result > 0;
        }
        

        public bool Delete(string resourceStarID)
        {
            int result = sqlMapper.Delete("DeleteResourceStar", resourceStarID);
            return result > 0;
        }
    }
}