using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_AnalysisAgVMs
{
    public partial class Basis_AnalysisAgVM : BaseCRUDVM<Basis_AnalysisAg>
    {
        public List<ComboSelectListItem> AllADictionarys { get; set; }
        public List<ComboSelectListItem> AllDevices { get; set; }

        public Basis_AnalysisAgVM()
        {
            SetInclude(x => x.ADictionary);
            SetInclude(x => x.Device);
        }

        protected override void InitVM()
        {
            AllADictionarys = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
            AllDevices = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
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
