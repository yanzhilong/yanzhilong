using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Helper;
using yanzhilong.Domain;
using yanzhilong.Models;

namespace yanzhilong.Service
{
    public class ResourceStarService
    {
        private SqlMapper sqlMapper = null;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ResourceStarService()
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

        public IList<ResourceStar> GetResourceStars(int pageCount)
        {
            //Page page = PageHelper.makePage(pageCount);
            //PageModel pagemodel = new PageModel(Constant.PAGESIZE, pageCount, productCRUD.GetCount());
            IList<ResourceStar> resourceStarList = sqlMapper.QueryForList<ResourceStar>("SelectAllResourceStar", null, 0, 10);
            return resourceStarList;
        }

        public PageModel GetPagingViewModel(int currentPage, int pageSize)
        {
            int count = sqlMapper.QueryForObject<int>("SelecResourceStarCount", null);
            PageModel pagemodel = new PageModel(Constant.PAGESIZE, currentPage, count);
            return pagemodel;
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

        public IList<ResourceStarType> getResourceStarTypes()
        {

            IList<ResourceStarType> rsts = new List<ResourceStarType>();
            ResourceStarType rst1 = new ResourceStarType();
            rst1.ID = ResourceType.ARTICLE;
            rst1.Name = "文章";
            ResourceStarType rst2 = new ResourceStarType();
            rst2.ID = ResourceType.PRODUCT;
            rst2.Name = "产品";
            ResourceStarType rst3 = new ResourceStarType();
            rst3.ID = ResourceType.TUTORIALS;
            rst3.Name = "教程";
            rsts.Add(rst1);
            rsts.Add(rst2);
            rsts.Add(rst3);

            return rsts;
        }
        
    }
}