using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_CleanClockVMs
{
    public partial class Business_CleanClockBatchVM : BaseBatchVM<Business_CleanClock, Business_CleanClock_BatchEdit>
    {
        public Business_CleanClockBatchVM()
        {
            ListVM = new Business_CleanClockListVM();
            LinkedVM = new Business_CleanClock_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Business_CleanClock_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
