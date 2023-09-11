using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_AlarmVMs
{
    public partial class Business_AlarmBatchVM : BaseBatchVM<Business_Alarm, Business_Alarm_BatchEdit>
    {
        public Business_AlarmBatchVM()
        {
            ListVM = new Business_AlarmListVM();
            LinkedVM = new Business_Alarm_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Business_Alarm_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
