using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Basis
{
    public class Basis_DustType : PersistPoco, ITenant
    {
        [Display(Name = "类别名称")]
        public string Name { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
