using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_AreaDictionaryVMs
{
    public partial class Sys_AreaDictionarySearcher : BaseSearcher
    {
        [Display(Name = "名称")]
        public String Name { get; set; }
        [Display(Name = "区域代码")]
        public String AreaCode { get; set; }
        public List<ComboSelectListItem> AllParents { get; set; }
        [Display(Name = "_Admin.Parent")]
        public Guid? ParentId { get; set; }

        protected override void InitVM()
        {
            AllParents = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
