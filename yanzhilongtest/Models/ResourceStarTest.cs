using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Models;
using System.Collections.Generic;
using yanzhilong.Helper;

namespace yanzhilongtest
{
    [TestClass]
    public class ResourceStarTest
    {
        [TestMethod]
        public void ResourceStarCreate()
        {
            ResourceStarCRUD resourceStarCRUD = new ResourceStarCRUD();
            ResourceStar resourceStar = new ResourceStar();
            resourceStar.ResourceStarID = Guid.NewGuid().ToString();
            resourceStar.ResourceID = "f3557d62-c521-48d4-9aea-5b23095b5005";
            resourceStar.ResourceType = ResourceType.PRODUCT;
            Assert.IsTrue(resourceStarCRUD.Create(resourceStar));
    }

        [TestMethod]
        public void ResourceStarDelete()
        {
            ResourceStarCRUD resourceStarCRUD = new ResourceStarCRUD();
            Assert.IsTrue(resourceStarCRUD.Delete("50fcb844-9648-4892-bbc6-2ea4fc79be1f"));
        }

        [TestMethod]
        public void ResourceStarUpdate()
        {
            ResourceStarCRUD resourceStarCRUD = new ResourceStarCRUD();
            ResourceStar resourceStar = new ResourceStar();
            resourceStar.ResourceStarID = "9202ec4c-c09e-4064-a794-5db497a03a37";
            resourceStar.ResourceID = Guid.NewGuid().ToString();
            resourceStar.ResourceType = 1;
            Assert.IsTrue(resourceStarCRUD.Update(resourceStar));
        }

        [TestMethod]
        public void GetResourceStarById()
        {
            ResourceStarCRUD resourceStarCRUD = new ResourceStarCRUD();
            ResourceStar resourceStar = resourceStarCRUD.GetResourceStarById("9202ec4c-c09e-4064-a794-5db497a03a37");
            Assert.IsNotNull(resourceStar);
        }

        [TestMethod]
        public void GetResourceStarByType()
        {
            ResourceStarCRUD resourceStarCRUD = new ResourceStarCRUD();
            IList<ResourceStar> resourceStars = resourceStarCRUD.GeResourceStarByType(ResourceType.PRODUCT);
            Assert.IsNotNull(resourceStars);
        }

        [TestMethod]
        public void GetResourceStars()
        {
            ResourceStarCRUD resourceStarCRUD = new ResourceStarCRUD();
            IList<ResourceStar> resourceStars = resourceStarCRUD.GetResourceStars();
            Assert.IsNotNull(resourceStars);
        }
    }
}
