using System;

namespace CaShare.Core.Model
{
    public class Absence
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public string Comment { get; set; }
    }
}
