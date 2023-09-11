using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DeviceVMs
{
    public partial class Basis_DeviceTemplateVM : BaseTemplateVM
    {
        [Display(Name = "设备名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Basis_Device>(x => x.Name);
        [Display(Name = "设备编号")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<Basis_Device>(x => x.Code);
        public ExcelPropety DT_Excel = ExcelPropety.CreateProperty<Basis_Device>(x => x.DTId);
        public ExcelPropety Area_Excel = ExcelPropety.CreateProperty<Basis_Device>(x => x.AreaId);
        [Display(Name = "位置备注")]
        public ExcelPropety Place_Excel = ExcelPropety.CreateProperty<Basis_Device>(x => x.Place);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Basis_Device>(x => x.TenantCode);

	    protected override void InitVM()
        {
            DT_Excel.DataType = ColumnDataType.ComboBox;
            DT_Excel.ListItems = DC.Set<Basis_DeviceType>().GetSelectListItems(Wtm, y => y.Name);
            Area_Excel.DataType = ColumnDataType.ComboBox;
            Area_Excel.ListItems = DC.Set<Basis_Area>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Basis_DeviceImportVM : BaseImportVM<Basis_DeviceTemplateVM, Basis_Device>
    {

    }

}
