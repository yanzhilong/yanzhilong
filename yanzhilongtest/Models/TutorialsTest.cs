﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Domain;
using System.Collections.Generic;
using System.IO;
using yanzhilong.Service;

namespace yanzhilongtest
{
    [TestClass]
    public class TutorialsTest
    {

        public string ReadFile(string filename)
        {
            string basedir = Path.GetFullPath("..\\..\\");
            string file = basedir + "Models\\File\\" + filename;
            StreamReader sr = new StreamReader(file);
            string result = sr.ReadToEnd();
            sr.Close();
            return result;
        }

        [TestMethod]
        public void TutorialsCreate()
        {
            TutorialsService tutorialsCRUD = new TutorialsService();
            Tutorials tutorials = new Tutorials();
            tutorials.TutorialsID = Guid.NewGuid().ToString();
            tutorials.Title = "测试";
            tutorials.Content = ReadFile("aa.txt");
            tutorials.CreateAt = DateTime.Now;
            tutorials.Disc = "Disc 测试";
            tutorials.Notes = "Notes 测试";
            User user = new User();
            user.UserID = "1f1c4189-3792-4a91-8d08-c0d04e18a0ae";
            tutorials.user = user;
            tutorialsCRUD.Create(tutorials);
            Assert.IsNotNull(tutorialsCRUD.GetTutorialsById(tutorials.TutorialsID));
    }

        [TestMethod]
        public void TutorialsDelete()
        {
            TutorialsService tutorialsCRUD = new TutorialsService();
            tutorialsCRUD.Delete("ad6b3dbb-f9d2-4d38-b601-42cb36a1120a");
            Assert.IsNull(tutorialsCRUD.GetTutorialsById("ad6b3dbb-f9d2-4d38-b601-42cb36a1120a"));
        }

        [TestMethod]
        public void TutorialsUpdate()
        {
            TutorialsService tutorialsCRUD = new TutorialsService();
            Tutorials tutorials = new Tutorials();
            tutorials.TutorialsID = "1394f8b1-e734-4231-8c52-d1cba8e2fbf7";
            tutorials.Title = "爬虫33";
            tutorials.Content = "";
            tutorials.CreateAt = DateTime.Now;
            tutorials.Disc = "Disc";
            tutorials.Notes = "Notes";
            User user = new User();
            user.UserID = "1f1c4189-3792-4a91-8d08-c0d04e18a0ae";
            tutorials.user = user;
            tutorialsCRUD.Update(tutorials);
        }

        [TestMethod]
        public void GetTutorialsById()
        {
            TutorialsService tutorialsCRUD = new TutorialsService();
            Tutorials tutorials = tutorialsCRUD.GetTutorialsById("1394f8b1-e734-4231-8c52-d1cba8e2fbf7");
            Assert.IsNotNull(tutorials);
        }

        [TestMethod]
        public void GetTutorialses()
        {
            TutorialsService tutorialsCRUD = new TutorialsService();
            IList<Tutorials> tutorialses = tutorialsCRUD.GetTutorialses();
            Assert.IsNotNull(tutorialses);
        }

        [TestMethod]
        public void GetStarTutorialses()
        {
            TutorialsService tutorialsCRUD = new TutorialsService();
            IList<Tutorials> tutorialses = tutorialsCRUD.GetStarTutorialses();
            Assert.IsNotNull(tutorialses);
        }
        
    }
}
