using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_OutboundSettingVMs
{
    public partial class Business_OutboundSettingBatchVM : BaseBatchVM<Business_OutboundSetting, Business_OutboundSetting_BatchEdit>
    {
        public Business_OutboundSettingBatchVM()
        {
            ListVM = new Business_OutboundSettingListVM();
            LinkedVM = new Business_OutboundSetting_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Business_OutboundSetting_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
