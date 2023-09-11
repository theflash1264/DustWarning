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
    public partial class Business_CleanClockTemplateVM : BaseTemplateVM
    {
        [Display(Name = "清扫时间")]
        public ExcelPropety CleanTime_Excel = ExcelPropety.CreateProperty<Business_CleanClock>(x => x.CleanTime);
        [Display(Name = "记录人员姓名")]
        public ExcelPropety RecordName_Excel = ExcelPropety.CreateProperty<Business_CleanClock>(x => x.RecordName);
        [Display(Name = "操作人姓名")]
        public ExcelPropety OperateName_Excel = ExcelPropety.CreateProperty<Business_CleanClock>(x => x.OperateName);
        [Display(Name = "清扫情况记录")]
        public ExcelPropety Situation_Excel = ExcelPropety.CreateProperty<Business_CleanClock>(x => x.Situation);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Business_CleanClock>(x => x.TenantCode);

	    protected override void InitVM()
        {
        }

    }

    public class Business_CleanClockImportVM : BaseImportVM<Business_CleanClockTemplateVM, Business_CleanClock>
    {

    }

}
