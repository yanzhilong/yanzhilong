using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Service;
using yanzhilong.Domain;
using System.Collections.Generic;
using System.Linq;
using yanzhilong.Repository;

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
        static TbPropertyMappingService tbPropertyMappingService = new TbPropertyMappingService();

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
        public void CreateTest2()
        {
            List<TbPropertyCategory> tbPropertyCategorys = tbPropertyCategoryService.GetEntrys(new TbPropertyCategory { }).ToList<TbPropertyCategory>();

            foreach (TbPropertyCategory tpc in tbPropertyCategorys)
            {
                List<TbProperty> tps = tbPropertyService.GetEntrys(new TbProperty { tbPropertyCategory = new TbPropertyCategory { Id = tpc.Id } }).ToList<TbProperty>();
                List<TbPropertyMapping> tpms = new List<TbPropertyMapping>();
                foreach(TbProperty tp in tps)
                {
                    TbProperty tpnew = getProperty(tp);
                    TbPropertyMapping tpm = new TbPropertyMapping();
                    tpm.Id = Guid.NewGuid().ToString();
                    tpm.tbProperty = tpnew;
                    tpm.tbPropertyCategory = tpc;
                    tpms.Add(tpm);
                }
                tbPropertyMappingService.AddEntrys(tpms);
            }
        }

        [TestMethod]
        public void CreateTest3()
        {
            TbProperty tp = new TbProperty();
            tp.Name = "纯羊毛";
            tp.ValueKey = "3229201";
            TbProperty tpnew = getProperty(tp);
            string name = "aa";
        }

        public TbProperty getProperty(TbProperty tbProperty)
        {
            IRepository<TbProperty> _Repository = new MbRepository<TbProperty>();
            TbProperty resultentry = _Repository.GetByCondition("SelectTbPropertyByCondition1", tbProperty);
            if(resultentry == null)
            {
                TbProperty tp = new TbProperty();
                tp.Id = Guid.NewGuid().ToString();
                tp.Name = tbProperty.Name;
                tp.ValueKey = tbProperty.ValueKey;
                tp.tbPropertyCategory = new TbPropertyCategory { Id = Guid.Empty.ToString() };
                tbPropertyService.AddEntry(tp);
                return tp;
            }
            return resultentry;
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
