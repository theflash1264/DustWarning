using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Business.Business_AlarmVMs
{
    public partial class Business_AlarmVM : BaseCRUDVM<Business_Alarm>
    {
        public List<ComboSelectListItem> AllDevices { get; set; }
        public List<ComboSelectListItem> AllAlarms { get; set; }

        public Business_AlarmVM()
        {
            SetInclude(x => x.Device);
            SetInclude(x => x.Alarm);
        }

        protected override void InitVM()
        {
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
            AllAlarms = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
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
