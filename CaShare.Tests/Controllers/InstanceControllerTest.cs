using CaShare.Controllers;
using CaShare.Core;
using CaShare.Core.Model;
using CaShare.ViewModels.Instances;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data;

namespace CaShare.Tests.Controllers
{
    [TestClass]
    public class InstanceControllerTest : TestBase
    {
        [TestMethod]
        public void Create_POST_CreatesNewInstance()
        {
            var user = new User { UserId = 12 };
            InitDb(db => db.Users.Add(user));

            var controller = new InstanceController();
            controller.UserInfo = new UserInfo { Id = 12 };


            var model = new CreateViewModel
            {
                Name = "Name",
                Started = DateTime.Parse("2013-01-24")
            };

            var redirect = controller.Create(model) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);

            var instances = DB.Use(db => db.Instances.Include("Users").ToList());

            Assert.AreEqual(1, instances.Count);
            var instance = instances.First();

            Assert.AreEqual("Name", instance.Name);
            Assert.AreEqual(DateTime.Parse("2013-01-24"), instance.Started);
            Assert.IsNull(instance.Closed);

            Assert.AreEqual(1, instance.Users.Count(u => u.UserId == 12));

        }

        [TestMethod]
        public void Index_ReturnsInstancesThatBelongsToTheUser()
        {
            var user = new User { UserId = 12 };
            var instanceA = new Instance{Name = "A", Started = DateTime.Parse("2010-01-01"), Users = new List<User>{ user } };
            var instanceB = new Instance { Name = "B", Started = DateTime.Parse("2011-01-01"), Closed = DateTime.Parse("2012-01-01"), Users = new List<User> { user } };
            var instanceC = new Instance { Name = "C", Started = DateTime.Parse("2012-01-01"), Users = new List<User> { user } };
            var instanceD = new Instance{Name = "D", Started = DateTime.Parse("2012-01-01") };

            InitDb(db =>
            {
                db.Users.Add(user);
                db.Instances.Add(instanceA);
                db.Instances.Add(instanceB);
                db.Instances.Add(instanceC);
                db.Instances.Add(instanceD);
            });

            var controller = new InstanceController();
            controller.UserInfo = new UserInfo { Id = 12 };
            var data = DataFromView<IndexViewModel>(controller.Index());

            Assert.AreEqual(3, data.Instances.Count());
            Assert.IsFalse(data.Instances.Any(i => i.Name == "D"));
        }
    }
}
