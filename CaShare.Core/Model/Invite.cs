using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaShare.Core.Model
{
    public class Invite
    {
        public Guid Id { get; set; }
        public string Email { get; set; }

        public byte[] Code { get; set; }

        public Guid? InviteeId { get; set; }
        public User Invitee { get; set; }



        public Guid InstanceId { get; set; }
        public Instance Instance { get; set; }


    }
}
