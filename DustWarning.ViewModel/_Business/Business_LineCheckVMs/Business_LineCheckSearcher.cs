using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Business.Business_LineCheckVMs
{
    public partial class Business_LineCheckSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllDevices { get; set; }
        public Guid? DeviceId { get; set; }
        [Display(Name = "抽查时间")]
        public DateRange CheckTime { get; set; }

        protected override void InitVM()
        {
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
