using CaShare.Controllers;
using CaShare.Core;
using CaShare.Core.Model;
using CaShare.ViewModels.Invites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CaShare.Tests.Controllers
{
    [TestClass]
    public class InviteControllerTest : TestBase
    {
        [TestMethod]
        [ExpectedException(typeof(HttpException))]
        public void Users_GET_NotMember_ShouldGetException()
        {
            var user = new User { UserId = 12 };
            var instance = new Instance { Started = DateTime.Now };

            InitDb(db =>
            {
                db.Users.Add(user);
                db.Instances.Add(instance);

                db.SaveChanges();
            });

            var controller = new InviteController();
            controller.UserInfo = new UserInfo { Id = 12 };

            var data = DataFromView<InviteViewModel>(controller.Users(instance.Id));
        }

        [TestMethod]
        public void Users_GET_Member_ShouldGetGroupData()
        {
            var instance = InitWithSingleMember();

            var controller = new InviteController();
            controller.UserInfo = new UserInfo { Id = 12 };

            var data = DataFromView<InviteViewModel>(controller.Users(instance.Id));

            Assert.AreEqual("Name", data.InstanceName);
            Assert.AreEqual(instance.Id, data.InstanceId);
        }

        [TestMethod]
        public void Users_POST_NewMember_ShouldSendInvite()
        {
            var instance = InitWithSingleMember();

            var controller = new InviteController();
            controller.UserInfo = new UserInfo { Id = 12 };

            var vm = new InviteViewModel
            {
                Emails = "testmail@mail.com"
            };

            var result = controller.Users(instance.Id, vm) as RedirectToRouteResult;
            Assert.IsNotNull(result);

            DB.Use(db =>
            {
                var invite = db.Invites.Single();
                Assert.AreEqual("testmail@mail.com", invite.Email);
                Assert.IsNotNull(invite.Code);
                Assert.AreEqual(instance.Id, invite.InstanceId);

                Assert.AreEqual(1, db.Users.Count());
            });
            
        }



        private Instance InitWithSingleMember()
        {
            var user = new User { UserId = 12 };
            var instance = new Instance { Started = DateTime.Now, Name = "Name", Users = new List<User> { user } };

            InitDb(db =>
            {
                db.Users.Add(user);
                db.Instances.Add(instance);

                db.SaveChanges();
            });
            return instance;
        }
    }
}
