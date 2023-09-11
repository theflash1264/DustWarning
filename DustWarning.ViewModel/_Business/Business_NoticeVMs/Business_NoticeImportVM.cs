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
    public partial class Business_NoticeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "标题")]
        public ExcelPropety Title_Excel = ExcelPropety.CreateProperty<Business_Notice>(x => x.Title);
        [Display(Name = "内容")]
        public ExcelPropety Content_Excel = ExcelPropety.CreateProperty<Business_Notice>(x => x.Content);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Business_Notice>(x => x.TenantCode);

	    protected override void InitVM()
        {
        }

    }

    public class Business_NoticeImportVM : BaseImportVM<Business_NoticeTemplateVM, Business_Notice>
    {

    }

}
