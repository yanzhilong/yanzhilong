using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilongtest
{
    [TestClass]
    class TemplateTest
    {
        [TestMethod]
        public void TestMethod1()
        {

        }


        [ClassInitialize]
        public static void Init(TestContext context)

        {
            Console.WriteLine("Use ClassCleanup to run code before all tests in a class have run.");
        }



        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("Use TestCleanup to run code before you run each test.");
        }


        [TestMethod]
        public void TestAMethodOrFunction()
        {
            Assert.AreEqual(3, 3);
        }

        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("Use TestCleanup to run code after you run each test.");
        }


        [ClassCleanup]
        public static void Cleanup()
        {
            Console.WriteLine("Use ClassCleanup to run code after all tests in a class have run.");

        }
    }
}
