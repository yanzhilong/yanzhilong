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
    public class ViewTotalService
    {
        IRepository<ViewTotal> repository = new MbRepository<ViewTotal>();
        public void Create(ViewTotal resourceStar)
        {
            repository.Insert("InsertViewTotal", resourceStar);
        }

        public ViewTotal GetViewTotalByResourceID(string ResourceID)
        {
            ViewTotal ViewTotal = repository.GetByCondition("SelectViewTotalByResoutceID", ResourceID);
            return ViewTotal;
        }
            
        public void Update(ViewTotal ViewTotal)
        {
            repository.Update("UpdateViewTotal", ViewTotal);
        }

        public void DeleteByResourceID(string ResourceID)
        {
            repository.Delete("DeleteViewTotalByResourceID", ResourceID);
        }

        public void PageViewDetails(string ResourceID)
        {
            ViewTotal pvc = GetViewTotalByResourceID(ResourceID);
            if (pvc == null)
            {
                pvc = new ViewTotal();
                pvc.Id = Guid.NewGuid().ToString();
                pvc.ResourceID = ResourceID;
                pvc.Total = 1;
                Create(pvc);
            }else
            {
                pvc.Total++;
                Update(pvc);
            }
        }
    }
}