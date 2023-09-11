using DustWarning.Model.Basis;
using DustWarning.Model.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Business
{
    public class Business_Alarm : PersistPoco, ITenant
    {
        public Basis_Device Device { get; set; }
        [Display(Name = "设备")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? DeviceId { get; set; }

        public Sys_Dictionary Alarm { get; set; }
        [Display(Name = "报警类型")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? AlarmId { get; set; }
        [Display(Name = "报警信息")]
        public string AlarmInformation { get; set; }
        [Display(Name = "报警开始时间")]
        public DateTime? StarTime { get; set; }
        [Display(Name = "报警结束时间")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "持续时长（小时）")]
        public decimal Continued { get; set; }
        [Display(Name = "报警状态")]
        public int State { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
