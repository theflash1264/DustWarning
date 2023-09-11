using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DataForwardVMs
{
    public partial class Sys_DataForwardBatchVM : BaseBatchVM<Sys_DataForward, Sys_DataForward_BatchEdit>
    {
        public Sys_DataForwardBatchVM()
        {
            ListVM = new Sys_DataForwardListVM();
            LinkedVM = new Sys_DataForward_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Sys_DataForward_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
