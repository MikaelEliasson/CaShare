using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaShare.Core.Model
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public User Sender { get; set; }
        public Guid SenderId { get; set; }
        public User Reciever { get; set; }
        public Guid RecieverId { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Confirmed { get; set; }

        public int InstanceId { get; set; }
        public Instance Instance { get; set; }
    }
}
