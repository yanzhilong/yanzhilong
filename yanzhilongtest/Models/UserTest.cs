using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Models;
using System.Collections.Generic;
using yanzhilong.Helper;

namespace yanzhilongtest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserCreate()
        {
            UserCRUD userCRUD = new UserCRUD();
            User user = new User();
            user.UserID = Guid.NewGuid().ToString();
            user.UserName = "yanzhilong";
            user.Email = "51877421@qq.com";
            user.MobilePhone = "15959210703";
            user.PasswordHash = PasswordHelper.GetMd5HashStr("GFDonx123");
            user.CreateAt = DateTime.Now;
            
            Assert.IsTrue(userCRUD.Create(user));
    }

        [TestMethod]
        public void UserDelete()
        {
            UserCRUD userCRUD = new UserCRUD();
            Assert.IsTrue(userCRUD.Delete("a999b733-c127-413d-8c8a-fc3e9dea07e9"));
        }
        
        [TestMethod]
        public void UserUpdate()
        {
            UserCRUD userCRUD = new UserCRUD();
            User user = userCRUD.GetUserById("1f1c4189-3792-4a91-8d08-c0d04e18a0ae");
            user.DisplayName = "严志龙";
            Assert.IsTrue(userCRUD.Update(user));
        }

        [TestMethod]
        public void GetUserById()
        {
            UserCRUD userCRUD = new UserCRUD();
            User user = userCRUD.GetUserById("f2f52ac5-8a06-4b34-a648-798941244fbb");
            Assert.IsNotNull(user);
            Assert.IsTrue(user.PasswordHash == PasswordHelper.GetMd5HashStr("GFDonx123"));
        }

        [TestMethod]
        public void GetUsers()
        {
            UserCRUD userCRUD = new UserCRUD();
            IList<User> users = userCRUD.GetUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void CheckUser()
        {
            UserCRUD userCRUD = new UserCRUD();
            User user = new User();
            user.UserName = "yanzhilong";
            user.PasswordHash = "92701ED5C0BA89118A6B8FC1B2085E9";
            User user1 = userCRUD.CheckUser(user);
            Assert.IsNotNull(user1);
        }
    }
}
