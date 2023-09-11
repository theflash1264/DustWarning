using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_NoticeVMs
{
    public partial class Business_NoticeBatchVM : BaseBatchVM<Business_Notice, Business_Notice_BatchEdit>
    {
        public Business_NoticeBatchVM()
        {
            ListVM = new Business_NoticeListVM();
            LinkedVM = new Business_Notice_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Business_Notice_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
