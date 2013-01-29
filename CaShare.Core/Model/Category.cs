using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaShare.Core.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryType Type { get; set; }

        public int InstanceId { get; set; }
        public Instance Instance { get; set; }

        public ICollection<User> DefaultAffectedUsers { get; set; }
    }

    public enum CategoryType
    {
        SplitEqual = 0,
        BasedOnPresence = 1
    }
}
