﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_AreaDictionaryVMs
{
    public partial class Sys_AreaDictionaryVM : BaseCRUDVM<Sys_AreaDictionary>
    {
        public List<ComboSelectListItem> AllParents { get; set; }

        public Sys_AreaDictionaryVM()
        {
            SetInclude(x => x.Parent);
        }

        protected override void InitVM()
        {
            AllParents = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
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
