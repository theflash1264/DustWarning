using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Business
{
    public class Business_Notice : PersistPoco, ITenant
    {
        [Display(Name = "标题")]
        public string Title { get; set; }
        [Display(Name = "内容")]
        public string Content { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
