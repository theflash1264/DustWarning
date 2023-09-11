using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_DeviceTypeVMs
{
    public partial class Basis_DeviceTypeVM : BaseCRUDVM<Basis_DeviceType>
    {
        public List<ComboSelectListItem> AllMessageTypes { get; set; }
        public List<ComboSelectListItem> AllAgreementTypes { get; set; }

        public Basis_DeviceTypeVM()
        {
            SetInclude(x => x.MessageType);
            SetInclude(x => x.AgreementType);
        }

        protected override void InitVM()
        {
            AllMessageTypes = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
            AllAgreementTypes = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
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
