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
using System.Collections;

namespace yanzhilong.Service
{
    public class PageViewCountService
    {
        IRepository<PageViewCount> repository = new MbRepository<PageViewCount>();
        public void Create(PageViewCount resourceStar)
        {
            repository.Insert("InsertPageViewCount", resourceStar);
        }

        public PageViewCount GetPageViewCountByResourceID(string ResourceID)
        {
            PageViewCount pageViewCount = repository.GetByCondition("SelectPageViewCountByResoutceID", ResourceID);
            return pageViewCount;
        }
            
        public void Update(PageViewCount pageViewCount)
        {
            repository.Update("UpdatePageViewCount", pageViewCount);
        }

        public void DeleteByResourceID(string ResourceID)
        {
            repository.Delete("DeletePageViewCountByResourceID", ResourceID);
        }

        public void PageViewDetails(string ResourceID)
        {
            PageViewCount pvc = GetPageViewCountByResourceID(ResourceID);
            if (pvc == null)
            {
                pvc = new PageViewCount();
                pvc.PageViewCountID = Guid.NewGuid().ToString();
                pvc.ResourceID = ResourceID;
                pvc.Count = 1;
                Create(pvc);
            }else
            {
                pvc.Count++;
                Update(pvc);
            }
        }
    }
}