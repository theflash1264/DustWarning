using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Sys
{
    public class Sys_DataForward : PersistPoco, ITenant
    {
        [Display(Name = "名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
        public Sys_Dictionary FType { get; set; }
        [Required(ErrorMessage = "{0}是必填项")]
        [Display(Name = "转发类型")]
        public Guid? FTypeId { get; set; }

        [Display(Name = "ip地址")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Ip { get; set; }
        [Display(Name = "端口")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Port { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
