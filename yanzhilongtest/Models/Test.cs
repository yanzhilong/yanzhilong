using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace yanzhilongtest.Models
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void StringTest()
        {
            string str = "你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好你好";
            if(str.Length > 30)
            {
                str = str.Substring(0,30);
            }
            int length = str.Length;
        }
    }
}
