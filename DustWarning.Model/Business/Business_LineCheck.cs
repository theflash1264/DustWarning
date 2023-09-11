using DustWarning.Model.Basis;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Business
{
    public class Business_LineCheck : PersistPoco, ITenant
    {

        public Basis_Device Device { get; set; }
        [Display(Name = "设备")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? DeviceId { get; set; }

        public FrameworkUser FrameworkUser { get; set; }
        [Display(Name = "抽查人")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? FrameworkUserId { get; set; }
        [Display(Name = "抽查时间")]
        public DateTime? CheckTime { get; set; }
        [Display(Name = "抽查情况")]
        public string Situation { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
