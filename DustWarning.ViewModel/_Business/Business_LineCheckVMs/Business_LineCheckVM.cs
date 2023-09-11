using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Business.Business_LineCheckVMs
{
    public partial class Business_LineCheckVM : BaseCRUDVM<Business_LineCheck>
    {
        public List<ComboSelectListItem> AllDevices { get; set; }
        public List<ComboSelectListItem> AllFrameworkUsers { get; set; }

        public Business_LineCheckVM()
        {
            SetInclude(x => x.Device);
            SetInclude(x => x.FrameworkUser);
        }

        protected override void InitVM()
        {
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
            AllFrameworkUsers = DC.Set<FrameworkUser>().GetSelectListItems(Wtm, y => y.Name);
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
