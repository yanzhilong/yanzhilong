using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Models;
using System.Collections.Generic;
using System.IO;

namespace yanzhilongtest
{
    [TestClass]
    public class FileTest
    {
        [TestMethod]
        public void FileTest1()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            dir = Path.GetFullPath("..\\..\\");
            string file = dir + "Models\\File\\aa.txt";
            if (File.Exists(file))
            {
                throw new FileLoadException();
            }else
            {
                throw new FileNotFoundException();
            }
        }

        
    }
}
