using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Crs.Core.Infrastructure;
using yanzhilong.Service;
using yanzhilong.Domain;

/// <summary>
/// 使用CodeSmith自动生成
/// </summary>
namespace Crs.Services.Tests.ServiceTests
{
    [TestClass]
    public class TbPropertyCategoryServiceTest
    {
        static ITbPropertyCategoryService tbPropertyCategoryService;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            EngineContext.Initialize(false);
            tbPropertyCategoryService = EngineContext.Current.Resolve<ITbPropertyCategoryService>();
        }


        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("测试之前");
        }


        [TestMethod]
        public void CreateTest()
        {
            TbPropertyCategory tbPropertyCategory = new TbPropertyCategory();
            tbPropertyCategory.Id = Guid.NewGuid().ToString();
            
            tbPropertyCategoryService.AddEntry(tbPropertyCategory);

            TbPropertyCategory tbPropertyCategoryresult = tbPropertyCategoryService.GetEntry(new TbPropertyCategory { Id = tbPropertyCategory.Id });
            Assert.IsNotNull(tbPropertyCategoryresult);
        }

        [TestMethod]
        public void DeleteTest()
        {
            TbPropertyCategory tbPropertyCategory = new TbPropertyCategory();
            tbPropertyCategory.Id = "";

            tbPropertyCategoryService.DeleteEntry(tbPropertyCategory);

           TbPropertyCategory tbPropertyCategoryresult = tbPropertyCategoryService.GetEntry(new TbPropertyCategory { Id = tbPropertyCategory.Id });
            Assert.IsNull(tbPropertyCategoryresult);
        }

        [TestMethod]
        public void UpdateTest()
        {
            TbPropertyCategory tbPropertyCategory = new TbPropertyCategory();
            tbPropertyCategory.Id = "";
            tbPropertyCategory.Name = "NewValue";

            tbPropertyCategoryService.UpdateEntry(tbPropertyCategory);

            TbPropertyCategory tbPropertyCategoryresult = tbPropertyCategoryService.GetEntry(new TbPropertyCategory { Id = tbPropertyCategory.Id });
            Assert.AreEqual(tbPropertyCategoryresult.Name, tbPropertyCategory.Name);
        }

        [TestMethod]
        public void GetTest()
        {
            TbPropertyCategory tbPropertyCategory = new TbPropertyCategory();
            tbPropertyCategory.Id = "";

            TbPropertyCategory tbPropertyCategoryresult = tbPropertyCategoryService.GetEntry(new TbPropertyCategory { Id = tbPropertyCategory.Id });
            Assert.IsNotNull(tbPropertyCategoryresult);
        }

        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("测试之后");
        }


        [ClassCleanup]
        public static void Cleanup()
        {
            Console.WriteLine("所有测试之后");

        }
    }
}
