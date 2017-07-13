using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Service;
using yanzhilong.Domain;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 使用CodeSmith自动生成
/// </summary>
namespace Crs.Services.Tests.ServiceTests
{
    [TestClass]
    public class TbPropertyServiceTest
    {
        static TbPropertyService tbPropertyService = new TbPropertyService();
        static TbPropertyCategoryService tbPropertyCategoryService = new TbPropertyCategoryService();

        [ClassInitialize]
        public static void Init(TestContext context)
        {
        }


        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("测试之前");
        }


        [TestMethod]
        public void CreateTest1()
        {
            IList<TbProperty> tps = tbPropertyService.GetEntrys(new TbProperty { tbPropertyCategory = new TbPropertyCategory { Id = "c1d06a63-5615-4142-bbce-7853bdfed12e" } }).ToList<TbProperty>();

            List<TbProperty> tpnew = new List<TbProperty>();
            foreach (TbProperty tp in tps)
            {
                tp.Id = Guid.NewGuid().ToString();
                tp.tbPropertyCategory = new TbPropertyCategory { Id = "76bf0abb-1c72-4f21-9ca1-1f6668e9ce39" };
                tpnew.Add(tp);
            }
            tbPropertyService.AddEntrys(tps);
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
