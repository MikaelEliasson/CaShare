using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaShare.ViewModels.Instances
{
    public class CreateViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Closed { get; set; }
    }
}