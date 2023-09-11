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
    public class Basis_DeviceType : PersistPoco, ITenant
    {
        [Display(Name = "类别名称")]
        public string Name { get; set; }
        public Sys_Dictionary MessageType { get; set; }
        [Display(Name = "通讯类型")]
        public Guid? MessageTypeId { get; set; }

        public Sys_Dictionary AgreementType { get; set; }
        [Display(Name = "协议类型")]
        public Guid? AgreementTypeId { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
