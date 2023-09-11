using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_AreaVMs
{
    public partial class Basis_AreaSearcher : BaseSearcher
    {
        [Display(Name = "名称")]
        public String Name { get; set; }
        [Display(Name = "区域编码")]
        public String AreaCode { get; set; }
        public String TenantCode { get; set; }

        protected override void InitVM()
        {
        }

    }
}
