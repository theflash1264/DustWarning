using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DustTypeVMs
{
    public partial class Basis_DustTypeSearcher : BaseSearcher
    {
        [Display(Name = "类别名称")]
        public String Name { get; set; }
        public String TenantCode { get; set; }

        protected override void InitVM()
        {
        }

    }
}
