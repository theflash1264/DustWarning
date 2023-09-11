using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_AnalysisAgVMs
{
    public partial class Basis_AnalysisAgSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllADictionarys { get; set; }
        public Guid? ADictionaryId { get; set; }
        public List<ComboSelectListItem> AllDevices { get; set; }
        public Guid? DeviceId { get; set; }
        public String TenantCode { get; set; }

        protected override void InitVM()
        {
            AllADictionarys = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
