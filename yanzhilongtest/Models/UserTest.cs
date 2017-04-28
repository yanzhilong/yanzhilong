using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using yanzhilong.Domain;
using System.Collections.Generic;
using yanzhilong.Helper;
using yanzhilong.Service;

namespace yanzhilongtest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void UserCreate()
        {
            UserService userCRUD = new UserService();
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
            UserService userCRUD = new UserService();
            Assert.IsTrue(userCRUD.Delete("a999b733-c127-413d-8c8a-fc3e9dea07e9"));
        }
        
        [TestMethod]
        public void UserUpdate()
        {
            UserService userCRUD = new UserService();
            User user = userCRUD.GetUserById("1f1c4189-3792-4a91-8d08-c0d04e18a0ae");
            user.DisplayName = "严志龙";
            Assert.IsTrue(userCRUD.Update(user));
        }

        [TestMethod]
        public void GetUserById()
        {
            UserService userCRUD = new UserService();
            User user = userCRUD.GetUserById("f2f52ac5-8a06-4b34-a648-798941244fbb");
            Assert.IsNotNull(user);
            Assert.IsTrue(user.PasswordHash == PasswordHelper.GetMd5HashStr("GFDonx123"));
        }

        [TestMethod]
        public void GetUsers()
        {
            UserService userCRUD = new UserService();
            IList<User> users = userCRUD.GetUsers();
            Assert.IsNotNull(users);
        }

        [TestMethod]
        public void CheckUser()
        {
            UserService userCRUD = new UserService();
            User user = new User();
            user.UserName = "yanzhilong";
            user.PasswordHash = "92701ED5C0BA89118A6B8FC1B2085E9";
            User user1 = userCRUD.CheckUser(user);
            Assert.IsNotNull(user1);
        }
    }
}
