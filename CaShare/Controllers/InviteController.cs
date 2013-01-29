using CaShare.Core;
using CaShare.Core.Model;
using CaShare.ViewModels.Invites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaShare.Controllers
{
    public class InviteController : ControllerBase
    {

        public ActionResult Users(int id)
        {
            return DB.Use(db =>
            {
                var instance = db.Instances.Find(id);
                var userId = UserInfo.Id;
                if (!db.IsMemberOfInstance(id, userId))
                {
                    throw new HttpException(401, "User has no access to this group");
                }

                return View(new InviteViewModel
                {
                    InstanceId = id,
                    InstanceName = instance.Name
                });
            });
        }

        [HttpPost]
        public ActionResult Users(int id, InviteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emails = model.Emails
                    .Split(Environment.NewLine.ToArray())
                    .Select(str => str.Trim().ToLower())
                    .ToList();
                DB.Use(db =>
                {
                    var existingUsers = db.Users.Where(u => emails.Contains(u.Email)).Select(u => new { u.UserId, u.Email }).ToList();
                    var newEmails = emails.Except(existingUsers.Select(u => u.Email));

                    foreach (var email in newEmails)
                    {
                        var invite = new Invite { Email = email, InstanceId = id, Code = GetRandomString() };
                        db.Invites.Add(invite);
                    }
                    db.SaveChanges();
                });

                return RedirectToAction("");

            }
            return View(model);
        }

            /// <summary>
        /// See: http://stackoverflow.com/a/4137076/507279
        /// </summary>
        public static string GetRandomString()
        {
            string rStr = Path.GetRandomFileName();
            rStr = rStr.Replace(".", ""); // For Removing the .
            return rStr;
        }

    }
}
