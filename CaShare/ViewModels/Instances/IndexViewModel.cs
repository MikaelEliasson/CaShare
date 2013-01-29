using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaShare.ViewModels.Instances
{
    public class IndexViewModel : ViewModelBase
    {
        public IEnumerable<InstanceForList> Instances { get; set; }
    }

    public class InstanceForList{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public DateTime Started { get; set; }
    }
}