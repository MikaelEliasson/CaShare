using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaShare.Core.Model
{
    public class Expense
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Shop { get; set; }

        public User Owner { get; set; }
        public Guid OwnerId { get; set; }

        public ICollection<User> AffectedUsers { get; set; }

        public Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public int InstanceId { get; set; }
        public Instance Instance { get; set; }
    }
}
