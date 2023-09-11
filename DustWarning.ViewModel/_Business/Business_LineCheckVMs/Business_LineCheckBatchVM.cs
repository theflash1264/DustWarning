using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_LineCheckVMs
{
    public partial class Business_LineCheckBatchVM : BaseBatchVM<Business_LineCheck, Business_LineCheck_BatchEdit>
    {
        public Business_LineCheckBatchVM()
        {
            ListVM = new Business_LineCheckListVM();
            LinkedVM = new Business_LineCheck_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Business_LineCheck_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
