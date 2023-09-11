using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_DetectionItmeVMs
{
    public partial class Basis_DetectionItmeVM : BaseCRUDVM<Basis_DetectionItme>
    {
        public List<ComboSelectListItem> AllUDictionarys { get; set; }

        public Basis_DetectionItmeVM()
        {
            SetInclude(x => x.UDictionary);
        }

        protected override void InitVM()
        {
            AllUDictionarys = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
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
