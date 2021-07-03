using FinalProject_LMS.VMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject_LMS.ViewModels
{
    public class SummaryVM
    {
        public SummaryVMQ SummaryVMQ { get; set; }
        public int cor { get; set; }
        public int worng { get; set; }
        public int tot { get; set; }
    }
}