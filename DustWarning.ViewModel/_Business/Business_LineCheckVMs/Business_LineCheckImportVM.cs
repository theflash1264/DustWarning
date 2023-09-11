using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Business.Business_LineCheckVMs
{
    public partial class Business_LineCheckTemplateVM : BaseTemplateVM
    {
        public ExcelPropety Device_Excel = ExcelPropety.CreateProperty<Business_LineCheck>(x => x.DeviceId);
        public ExcelPropety FrameworkUser_Excel = ExcelPropety.CreateProperty<Business_LineCheck>(x => x.FrameworkUserId);
        [Display(Name = "抽查时间")]
        public ExcelPropety CheckTime_Excel = ExcelPropety.CreateProperty<Business_LineCheck>(x => x.CheckTime);
        [Display(Name = "抽查情况")]
        public ExcelPropety Situation_Excel = ExcelPropety.CreateProperty<Business_LineCheck>(x => x.Situation);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Business_LineCheck>(x => x.TenantCode);

	    protected override void InitVM()
        {
            Device_Excel.DataType = ColumnDataType.ComboBox;
            Device_Excel.ListItems = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
            FrameworkUser_Excel.DataType = ColumnDataType.ComboBox;
            FrameworkUser_Excel.ListItems = DC.Set<FrameworkUser>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Business_LineCheckImportVM : BaseImportVM<Business_LineCheckTemplateVM, Business_LineCheck>
    {

    }

}
