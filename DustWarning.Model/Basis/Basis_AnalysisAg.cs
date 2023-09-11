using DustWarning.Model.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Basis
{
    public class Basis_AnalysisAg : PersistPoco, ITenant
    {
        public Sys_Dictionary ADictionary { get; set; }
        [Display(Name = "协议")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? ADictionaryId { get; set; }

        public Basis_Device Device { get; set; }
        [Display(Name = "设备")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? DeviceId { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    } 
}
