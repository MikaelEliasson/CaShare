using System;
using System.Collections.Generic;

namespace CaShare.Core.Model
{
    public class Instance
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Started { get; set; }
        public DateTime? Closed { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
