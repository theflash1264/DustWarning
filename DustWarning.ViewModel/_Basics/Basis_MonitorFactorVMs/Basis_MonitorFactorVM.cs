using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_MonitorFactorVMs
{
    public partial class Basis_MonitorFactorVM : BaseCRUDVM<Basis_MonitorFactor>
    {
        public List<ComboSelectListItem> AllDevices { get; set; }
        public List<ComboSelectListItem> AllMonitorFactors { get; set; }

        public Basis_MonitorFactorVM()
        {
            SetInclude(x => x.Device);
            SetInclude(x => x.MonitorFactor);
        }

        protected override void InitVM()
        {
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
            AllMonitorFactors = DC.Set<Basis_DetectionItme>().GetSelectListItems(Wtm, y => y.Name);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
