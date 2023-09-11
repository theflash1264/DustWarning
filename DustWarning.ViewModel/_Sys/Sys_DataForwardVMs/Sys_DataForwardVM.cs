using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DataForwardVMs
{
    public partial class Sys_DataForwardVM : BaseCRUDVM<Sys_DataForward>
    {
        public List<ComboSelectListItem> AllFTypes { get; set; }

        public Sys_DataForwardVM()
        {
            SetInclude(x => x.FType);
        }

        protected override void InitVM()
        {
            AllFTypes = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
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
