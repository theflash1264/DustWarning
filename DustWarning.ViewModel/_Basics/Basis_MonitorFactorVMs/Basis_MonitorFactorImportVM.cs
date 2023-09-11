using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_MonitorFactorVMs
{
    public partial class Basis_MonitorFactorTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Device_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.DeviceId);
        public ExcelPropety MonitorFactor_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.MonitorFactorId);
        [Display(Name = "上限值")]
        public ExcelPropety MaxNum_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.MaxNum);
        [Display(Name = "下限值")]
        public ExcelPropety MinNum_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.MinNum);
        [Display(Name = "是否零值报警")]
        public ExcelPropety IsZeroAlarm_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.IsZeroAlarm);
        [Display(Name = "零值报警时长(分钟)")]
        public ExcelPropety ZeroAlarmDuration_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.ZeroAlarmDuration);
        [Display(Name = "是否恒值报警")]
        public ExcelPropety IsConstantAlarm_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.IsConstantAlarm);
        [Display(Name = "恒值报警时长(分钟)")]
        public ExcelPropety ConstantAlarmDuration_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.ConstantAlarmDuration);
        [Display(Name = "排序")]
        public ExcelPropety Sort_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.Sort);
        [Display(Name = "是否显示")]
        public ExcelPropety IsShow_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.IsShow);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Basis_MonitorFactor>(x => x.TenantCode);

	    protected override void InitVM()
        {
            Device_Excel.DataType = ColumnDataType.ComboBox;
            Device_Excel.ListItems = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
            MonitorFactor_Excel.DataType = ColumnDataType.ComboBox;
            MonitorFactor_Excel.ListItems = DC.Set<Basis_DetectionItme>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Basis_MonitorFactorImportVM : BaseImportVM<Basis_MonitorFactorTemplateVM, Basis_MonitorFactor>
    {

    }

}
