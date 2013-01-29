using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaShare.Core.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string AccountInfo { get; set; }
        public string Email { get; set; }

        //Categories the user is default in

        //Abscences

        //Memberships
        public ICollection<Instance> Instances { get; set; }

    }

}
