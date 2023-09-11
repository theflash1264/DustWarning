using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_DeviceTypeVMs
{
    public partial class Basis_DeviceTypeSearcher : BaseSearcher
    {
        [Display(Name = "类别名称")]
        public String Name { get; set; }
        public List<ComboSelectListItem> AllMessageTypes { get; set; }
        public Guid? MessageTypeId { get; set; }
        public List<ComboSelectListItem> AllAgreementTypes { get; set; }
        public Guid? AgreementTypeId { get; set; }
        public String TenantCode { get; set; }

        protected override void InitVM()
        {
            AllMessageTypes = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
            AllAgreementTypes = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
