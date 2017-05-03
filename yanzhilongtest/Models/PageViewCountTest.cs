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
            PageViewCountService pageviewCountService = new PageViewCountService();
            PageViewCount pageViewCount = new PageViewCount();
            pageViewCount.PageViewCountID = Guid.NewGuid().ToString();
            pageViewCount.ResourceID = "f3557d62-c521-48d4-9aea-5b23095b5005";
            pageViewCount.Count = 10;
            pageviewCountService.Create(pageViewCount);
    }

        [TestMethod]
        public void PageViewCountDelete()
        {
            PageViewCountService pageviewCountService = new PageViewCountService();
            pageviewCountService.DeleteByResourceID("f3557d62-c521-48d4-9aea-5b23095b5005");
        }

        [TestMethod]
        public void PageViewCountUpdate()
        {
            PageViewCountService pageviewCountService = new PageViewCountService();
            PageViewCount pageViewCount = pageviewCountService.GetPageViewCountByResourceID("f3557d62-c521-48d4-9aea-5b23095b5005");
            pageViewCount.Count++;
            pageviewCountService.Update(pageViewCount);
        }

        [TestMethod]
        public void GetResourceStarByResourceID()
        {
            PageViewCountService pageviewCountService = new PageViewCountService();
            PageViewCount pageViewCount = pageviewCountService.GetPageViewCountByResourceID("f3557d62-c521-48d4-9aea-5b23095b5005"); ;
            Assert.IsNotNull(pageViewCount);
        }

       
    }
}
