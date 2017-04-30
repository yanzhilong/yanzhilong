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
    public class ResourceStarService
    {
        IRepository<ResourceStar> repository = new MbRepository<ResourceStar>();
        public void Create(ResourceStar resourceStar)
        {
            repository.Insert("InsertResourceStar", resourceStar);
        }
         
        public ResourceStar GetResourceStarById(string resourceStarID)
        {
            ResourceStar resourceStar = repository.GetByCondition("SelectResourceStarById", resourceStarID);
            return resourceStar;
        }

        public IList<ResourceStar> GetResourceStars()
        {
            IList<ResourceStar> resourceStars = repository.GetList("SelectAllResourceStar", null); 
            return resourceStars;
        }

        public IList<ResourceStar> GeResourceStarByType(int resourceTypeID)
        {
            IList<ResourceStar> resourceStars = repository.GetList("SelectAllResourceStarByType", resourceTypeID); 
            return resourceStars;
        }

        public IList<ResourceStar> GetResourceStars(int pageCount)
        {
            IList<ResourceStar> resourceStarList = repository.GetList("SelectAllResourceStar", null, pageCount); 
            return resourceStarList;
        }

        public int GetCount()
        {
            int count = repository.GetObject<int>("SelecResourceStarCount", null);
            return count;
        }

        public void Update(ResourceStar resourceStar)
        {
            repository.Update("UpdateResourceStar", resourceStar);
        }
        

        public void Delete(string resourceStarID)
        {
            repository.Delete("DeleteResourceStar", resourceStarID);
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