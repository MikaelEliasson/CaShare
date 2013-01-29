using CaShare.Core;
using CaShare.Core.Model;
using CaShare.ViewModels.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CaShare.Controllers
{
    public class InstanceController : ControllerBase
    {

        public ActionResult Index()
        {
            var userId = UserInfo.Id;
            var instances = DB.Use("LoadInstances", db => db.Instances.Where(i => i.Users.Any(u => u.UserId == userId)).ToList());

            return View(new IndexViewModel
            {
                Instances = instances
                    .OrderByDescending(i => i.Closed == null)
                    .ThenBy(i => i.Name)
                    .Select(x => new InstanceForList
                    {
                        Id = x.Id,
                        IsOpen = x.Closed == null,
                        Name = x.Name,
                        Started = x.Started
                    })
                    .ToList()
            });
        }

        public ActionResult Create()
        {
            return View(new CreateViewModel{Started = DateTime.Now });
        }

        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = UserInfo.Id;

                var instance = new Instance
                {
                    Name = model.Name.Trim(),
                    Started = model.Started,
                    Closed = model.Closed,
                    Users = new List<User>()
                };

                DB.Save(db => {
                    var user = db.Users.Find(userId);
                    instance.Users.Add(user);
                    db.Instances.Add(instance);
                });

                return RedirectToAction("Details", new { id = instance.Id });
                
            }
            return View(model);
        }
    }
}