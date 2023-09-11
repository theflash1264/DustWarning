using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DataForwardVMs
{
    public partial class Sys_DataForwardSearcher : BaseSearcher
    {
        [Display(Name = "名称")]
        public String Name { get; set; }
        public List<ComboSelectListItem> AllFTypes { get; set; }
        public Guid? FTypeId { get; set; }
        [Display(Name = "ip地址")]
        public String Ip { get; set; }
        [Display(Name = "端口")]
        public String Port { get; set; }
        public String TenantCode { get; set; }

        protected override void InitVM()
        {
            AllFTypes = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
