using CaShare.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaShare
{
    public static class QueryExtensions
    {
        public static bool IsMemberOfInstance(this Context source, int instanceId, int userId)
        {
            return source.Instances.Any(i => i.Id == instanceId && i.Users.Any(u => u.UserId == userId));
        }
    }
}
