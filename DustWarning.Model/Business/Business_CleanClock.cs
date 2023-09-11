using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Business
{
    public class Business_CleanClock : PersistPoco, ITenant
    {
        [Display(Name = "清扫时间")]
        public DateTime? CleanTime { get; set; }
        [Display(Name = "记录人员姓名")]
        public string RecordName { get; set; }
        [Display(Name = "操作人姓名")]
        public string OperateName { get; set; }
        [Display(Name = "清扫情况记录")]
        public string Situation { get; set; }

        [Display(Name = "附件")]
        public List<Business_CleanClockFile> CleanClockFile { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
