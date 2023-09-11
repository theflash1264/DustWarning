using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Basis
{
    public class Basis_Device : PersistPoco, ITenant
    {
        [Display(Name = "设备名称")]
        public string Name { get; set; }

        [Display(Name = "设备编号")]
        public string Code { get; set; }

        public Basis_DeviceType DT { get; set; }
        [Display(Name = "设备类别")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? DTId { get; set; }

        public Basis_Area Area { get; set; }
        [Display(Name = "所属区域")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? AreaId { get; set; }

        [Display(Name = "位置备注")]
        public string Place { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
