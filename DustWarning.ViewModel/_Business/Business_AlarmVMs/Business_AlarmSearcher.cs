using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Business.Business_AlarmVMs
{
    public partial class Business_AlarmSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllDevices { get; set; }
        public Guid? DeviceId { get; set; }
        public List<ComboSelectListItem> AllAlarms { get; set; }
        public Guid? AlarmId { get; set; }
        [Display(Name = "报警状态")]
        public Int32? State { get; set; }

        protected override void InitVM()
        {
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
            AllAlarms = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
