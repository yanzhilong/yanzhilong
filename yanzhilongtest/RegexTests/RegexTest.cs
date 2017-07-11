using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace yanzhilongtest.RegexTests
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void MatchValue()
        {
            string Source = "https://images.xiedu.biz/upload/20170519130741500047759315.jpg!bac";
            string RegexStr = @"\d.*\.jpg";
            Match mt = Regex.Match(Source, RegexStr);
            Console.WriteLine(mt.Value);

        }

        [TestMethod]
        public void ArrauTest()
        {
            string[][] propertys = new string[][]{ new string[] { "款式", "122276315" }, new string[] { "鞋底材质", "122216563" }, new string[] { "风格", "20608" },
                new string[] { "鞋面材质", "124128491" }, new string[] { "真皮材质工艺", "122216629" }, new string[] { "适用季节", "122216345" },
                new string[] { "鞋制作工艺", "122216632" }, new string[] { "图案", "20603" }, new string[] { "流行元素", "34272" },
                new string[] { "鞋跟、跟底款式", "122216561" }, new string[] { "场合", "122216515" },new string[] { "功能", "20019" },
                new string[] { "适合对象", "122216608" }, new string[] { "鞋头款式", "122216351" }, new string[] { "闭合方式", "20490" },
                new string[] { "鞋跟高", "1626698" }, new string[] { "鞋面内里材料,鞋面内里材质", "122216587" }, new string[] { "帮面内里材质,帮面材质", "139520082" } };

            foreach (string[] strs in propertys)
            {
                string[] s = strs;
            }
        }
    }
}
