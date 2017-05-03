using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Domain;
using System.Collections.Generic;
using yanzhilong.Helper;
using yanzhilong.Service;

namespace yanzhilongtest
{
    [TestClass]
    public class ResourceStarTest
    {
        [TestMethod]
        public void ResourceStarCreate()
        {
            ResourceStarService resourceStarCRUD = new ResourceStarService();
            ResourceStar resourceStar = new ResourceStar();
            resourceStar.ResourceStarID = Guid.NewGuid().ToString();
            resourceStar.ResourceID = "f3557d62-c521-48d4-9aea-5b23095b5005";
            resourceStar.ResourceType = ResourceType.PRODUCT;
            resourceStarCRUD.Create(resourceStar);
    }

        [TestMethod]
        public void ResourceStarDelete()
        {
            ResourceStarService resourceStarCRUD = new ResourceStarService();
            resourceStarCRUD.Delete("50fcb844-9648-4892-bbc6-2ea4fc79be1f");
        }

        [TestMethod]
        public void ResourceStarUpdate()
        {
            ResourceStarService resourceStarCRUD = new ResourceStarService();
            ResourceStar resourceStar = new ResourceStar();
            resourceStar.ResourceStarID = "9202ec4c-c09e-4064-a794-5db497a03a37";
            resourceStar.ResourceID = Guid.NewGuid().ToString();
            resourceStar.ResourceType = 1;
            resourceStarCRUD.Update(resourceStar);
        }

        [TestMethod]
        public void GetResourceStarById()
        {
            ResourceStarService resourceStarCRUD = new ResourceStarService();
            ResourceStar resourceStar = resourceStarCRUD.GetResourceStarById("9202ec4c-c09e-4064-a794-5db497a03a37");
            Assert.IsNotNull(resourceStar);
        }

        [TestMethod]
        public void GetResourceStarByType()
        {
            ResourceStarService resourceStarCRUD = new ResourceStarService();
            IList<ResourceStar> resourceStars = resourceStarCRUD.GeResourceStarByType(ResourceType.PRODUCT);
            Assert.IsNotNull(resourceStars);
        }

        [TestMethod]
        public void GetResourceStars()
        {
            ResourceStarService resourceStarCRUD = new ResourceStarService();
            IList<ResourceStar> resourceStars = resourceStarCRUD.GetResourceStars();
            Assert.IsNotNull(resourceStars);
        }
    }
}
