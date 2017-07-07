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
    public class TbPropertyServiceTest
    {
        static ITbPropertyService tbPropertyService;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            EngineContext.Initialize(false);
            tbPropertyService = EngineContext.Current.Resolve<ITbPropertyService>();
        }


        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("测试之前");
        }


        [TestMethod]
        public void CreateTest()
        {
            TbProperty tbProperty = new TbProperty();
            tbProperty.Id = Guid.NewGuid().ToString();
            
            tbPropertyService.AddEntry(tbProperty);

            TbProperty tbPropertyresult = tbPropertyService.GetEntry(new TbProperty { Id = tbProperty.Id });
            Assert.IsNotNull(tbPropertyresult);
        }

        [TestMethod]
        public void DeleteTest()
        {
            TbProperty tbProperty = new TbProperty();
            tbProperty.Id = "";

            tbPropertyService.DeleteEntry(tbProperty);

           TbProperty tbPropertyresult = tbPropertyService.GetEntry(new TbProperty { Id = tbProperty.Id });
            Assert.IsNull(tbPropertyresult);
        }

        [TestMethod]
        public void UpdateTest()
        {
            TbProperty tbProperty = new TbProperty();
            tbProperty.Id = "";
            tbProperty.Name = "NewValue";

            tbPropertyService.UpdateEntry(tbProperty);

            TbProperty tbPropertyresult = tbPropertyService.GetEntry(new TbProperty { Id = tbProperty.Id });
            Assert.AreEqual(tbPropertyresult.Name, tbProperty.Name);
        }

        [TestMethod]
        public void GetTest()
        {
            TbProperty tbProperty = new TbProperty();
            tbProperty.Id = "";

            TbProperty tbPropertyresult = tbPropertyService.GetEntry(new TbProperty { Id = tbProperty.Id });
            Assert.IsNotNull(tbPropertyresult);
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
