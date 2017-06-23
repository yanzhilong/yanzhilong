using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Domain;
using System.Collections.Generic;
using yanzhilong.Helper;
using yanzhilong.Service;

namespace yanzhilongtest
{
    [TestClass]
    public class PageViewCountTest
    {
        [TestMethod]
        public void ResourceStarCreate()
        {
            ViewTotalService pageviewCountService = new ViewTotalService();
            ViewTotal viewTotal = new ViewTotal();
            viewTotal.Id = Guid.NewGuid().ToString();
            viewTotal.ResourceID = "f3557d62-c521-48d4-9aea-5b23095b5005";
            viewTotal.Total = 10;
            pageviewCountService.Create(viewTotal);
    }

        [TestMethod]
        public void PageViewCountDelete()
        {
            ViewTotalService pageviewCountService = new ViewTotalService();
            pageviewCountService.DeleteByResourceID("f3557d62-c521-48d4-9aea-5b23095b5005");
        }

        [TestMethod]
        public void PageViewCountUpdate()
        {
            ViewTotalService pageviewCountService = new ViewTotalService();
            ViewTotal pageViewCount = pageviewCountService.GetViewTotalByResourceID("f3557d62-c521-48d4-9aea-5b23095b5005");
            pageViewCount.Total++;
            pageviewCountService.Update(pageViewCount);
        }

        [TestMethod]
        public void GetResourceStarByResourceID()
        {
            ViewTotalService pageviewCountService = new ViewTotalService();
            ViewTotal pageViewCount = pageviewCountService.GetViewTotalByResourceID("f3557d62-c521-48d4-9aea-5b23095b5005"); ;
            Assert.IsNotNull(pageViewCount);
        }

       
    }
}
