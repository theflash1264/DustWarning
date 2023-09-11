using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Business.Business_AlarmVMs
{
    public partial class Business_AlarmTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Device_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.DeviceId);
        public ExcelPropety Alarm_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.AlarmId);
        [Display(Name = "报警信息")]
        public ExcelPropety AlarmInformation_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.AlarmInformation);
        [Display(Name = "报警开始时间")]
        public ExcelPropety StarTime_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.StarTime);
        [Display(Name = "报警结束时间")]
        public ExcelPropety EndTime_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.EndTime);
        [Display(Name = "持续时长（小时）")]
        public ExcelPropety Continued_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.Continued);
        [Display(Name = "报警状态")]
        public ExcelPropety State_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.State);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Business_Alarm>(x => x.TenantCode);

	    protected override void InitVM()
        {
            Device_Excel.DataType = ColumnDataType.ComboBox;
            Device_Excel.ListItems = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
            Alarm_Excel.DataType = ColumnDataType.ComboBox;
            Alarm_Excel.ListItems = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Business_AlarmImportVM : BaseImportVM<Business_AlarmTemplateVM, Business_Alarm>
    {

    }

}
