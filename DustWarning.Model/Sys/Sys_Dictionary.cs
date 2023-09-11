using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Sys
{
    public class Sys_Dictionary : TreePoco<Sys_Dictionary>
    {
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
        [Display(Name = "编号")]
        public string Code { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
