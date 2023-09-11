using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_MonitorFactorVMs
{
    public partial class Basis_MonitorFactorSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllDevices { get; set; }
        public Guid? DeviceId { get; set; }

        protected override void InitVM()
        {
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
