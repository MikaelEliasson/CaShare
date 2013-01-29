using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaShare.ViewModels.Invites
{
    public class InviteViewModel : ViewModelBase
    {
        public int InstanceId { get; set; }
        public string InstanceName { get; set; }

        public string Emails { get; set; }
    }
}