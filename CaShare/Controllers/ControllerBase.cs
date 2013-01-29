using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaShare.Controllers
{
    public class ControllerBase : Controller
    {
        private UserInfo userInfo;

        public UserInfo UserInfo
        {
            get { return userInfo ?? (userInfo = GetUserInfo()); }
            set { userInfo = value; }
        }

        private UserInfo GetUserInfo()
        {
            throw new NotImplementedException();
        }

    }

    public class UserInfo
    {
        public int Id { get; set; }
    }
}