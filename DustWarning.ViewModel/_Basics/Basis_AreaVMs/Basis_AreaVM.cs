using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_AreaVMs
{
    public partial class Basis_AreaVM : BaseCRUDVM<Basis_Area>
    {
        public List<ComboSelectListItem> AllAreas { get; set; }
        public List<ComboSelectListItem> AllProvinces { get; set; }
        public List<ComboSelectListItem> AllCitys { get; set; }

        public Basis_AreaVM()
        {
            SetInclude(x => x.Area);
            SetInclude(x => x.Province);
            SetInclude(x => x.City);
        }

        protected override void InitVM()
        {
            AllAreas = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
            AllProvinces = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
            AllCitys = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
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
