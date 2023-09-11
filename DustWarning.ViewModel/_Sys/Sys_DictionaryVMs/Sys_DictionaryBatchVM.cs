using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DictionaryVMs
{
    public partial class Sys_DictionaryBatchVM : BaseBatchVM<Sys_Dictionary, Sys_Dictionary_BatchEdit>
    {
        public Sys_DictionaryBatchVM()
        {
            ListVM = new Sys_DictionaryListVM();
            LinkedVM = new Sys_Dictionary_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Sys_Dictionary_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
