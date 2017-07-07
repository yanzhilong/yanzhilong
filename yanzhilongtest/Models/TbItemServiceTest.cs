using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Service;
using yanzhilong.Domain;

/// <summary>
/// 使用CodeSmith自动生成
/// </summary>
namespace Crs.Services.Tests.ServiceTests
{
    [TestClass]
    public class TbItemServiceTest
    {
        static TbItemService tbItemService;

        [ClassInitialize]
        public static void Init(TestContext context)
        {

            tbItemService = new TbItemService();
        }


        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("测试之前");
        }


        [TestMethod]
        public void CreateTest()
        {
            TbItem tbItem = new TbItem();
            tbItem.Id = Guid.NewGuid().ToString();
            
            tbItemService.AddEntry(tbItem);

            TbItem tbItemresult = tbItemService.GetEntry(new TbItem { Id = tbItem.Id });
            Assert.IsNotNull(tbItemresult);
        }

        [TestMethod]
        public void DeleteTest()
        {
            TbItem tbItem = new TbItem();
            tbItem.Id = "";

            tbItemService.DeleteEntry(tbItem);

           TbItem tbItemresult = tbItemService.GetEntry(new TbItem { Id = tbItem.Id });
            Assert.IsNull(tbItemresult);
        }

        [TestMethod]
        public void UpdateTest()
        {
            TbItem tbItem = new TbItem();
            tbItem.Id = "";
            tbItem.title = "NewValue";

            tbItemService.UpdateEntry(tbItem);

            TbItem tbItemresult = tbItemService.GetEntry(new TbItem { Id = tbItem.Id });
            Assert.AreEqual(tbItemresult.title, tbItem.title);
        }

        [TestMethod]
        public void GetTest()
        {
            TbItem tbItem = new TbItem();
            tbItem.Id = "";

            TbItem tbItemresult = tbItemService.GetEntry(new TbItem { Id = tbItem.Id });
            Assert.IsNotNull(tbItemresult);
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
