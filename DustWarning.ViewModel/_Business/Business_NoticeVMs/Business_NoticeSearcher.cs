using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_NoticeVMs
{
    public partial class Business_NoticeSearcher : BaseSearcher
    {
        [Display(Name = "标题")]
        public String Title { get; set; }

        protected override void InitVM()
        {
        }

    }
}
