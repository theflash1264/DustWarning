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
    public class Basis_DetectionItme : PersistPoco, ITenant
    {
        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "编码")]
        public string Code { get; set; }
        public Sys_Dictionary UDictionary { get; set; }
        [Display(Name = "单位")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? UDictionaryId { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
