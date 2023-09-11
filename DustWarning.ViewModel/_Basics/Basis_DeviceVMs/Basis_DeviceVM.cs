using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DeviceVMs
{
    public partial class Basis_DeviceVM : BaseCRUDVM<Basis_Device>
    {
        public List<ComboSelectListItem> AllDTs { get; set; }
        public List<ComboSelectListItem> AllAreas { get; set; }

        public Basis_DeviceVM()
        {
            SetInclude(x => x.DT);
            SetInclude(x => x.Area);
        }

        protected override void InitVM()
        {
            AllDTs = DC.Set<Basis_DeviceType>().GetSelectListItems(Wtm, y => y.Name);
            AllAreas = DC.Set<Basis_Area>().GetSelectListItems(Wtm, y => y.Name);
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
