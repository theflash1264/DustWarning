using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_CleanClockVMs
{
    public partial class Business_CleanClockSearcher : BaseSearcher
    {
        [Display(Name = "清扫时间")]
        public DateRange CleanTime { get; set; }
        [Display(Name = "记录人员姓名")]
        public String RecordName { get; set; }
        [Display(Name = "操作人姓名")]
        public String OperateName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
