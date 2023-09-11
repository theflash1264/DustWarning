using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_AreaDictionaryVMs
{
    public partial class Sys_AreaDictionaryBatchVM : BaseBatchVM<Sys_AreaDictionary, Sys_AreaDictionary_BatchEdit>
    {
        public Sys_AreaDictionaryBatchVM()
        {
            ListVM = new Sys_AreaDictionaryListVM();
            LinkedVM = new Sys_AreaDictionary_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Sys_AreaDictionary_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
