using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Basis
{
    public class Basis_MonitorFactor : PersistPoco, ITenant
    {
        public Basis_Device Device { get; set; }
        [Display(Name = "设备")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? DeviceId { get; set; }

        public Basis_DetectionItme MonitorFactor { get; set; }
        [Display(Name = "设备")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? MonitorFactorId { get; set; }

        [Display(Name = "上限值")]
        public decimal MaxNum { get; set; }
        [Display(Name = "下限值")]
        public decimal MinNum { get; set; }
        [Display(Name = "是否零值报警")]
        public int? IsZeroAlarm { get; set; }
        [Display(Name = "零值报警时长(分钟)")]
        public int? ZeroAlarmDuration { get; set; }
        [Display(Name = "是否恒值报警")]
        public int? IsConstantAlarm { get; set; }
        [Display(Name = "恒值报警时长(分钟)")]
        public int? ConstantAlarmDuration { get; set; }
        [Display(Name = "排序")]
        public int Sort { get; set; }

        [Display(Name = "是否显示")]
        public int? IsShow { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
