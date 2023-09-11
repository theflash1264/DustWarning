using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_DeviceTypeVMs
{
    public partial class Basis_DeviceTypeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "类别名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Basis_DeviceType>(x => x.Name);
        public ExcelPropety MessageType_Excel = ExcelPropety.CreateProperty<Basis_DeviceType>(x => x.MessageTypeId);
        public ExcelPropety AgreementType_Excel = ExcelPropety.CreateProperty<Basis_DeviceType>(x => x.AgreementTypeId);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Basis_DeviceType>(x => x.TenantCode);

	    protected override void InitVM()
        {
            MessageType_Excel.DataType = ColumnDataType.ComboBox;
            MessageType_Excel.ListItems = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
            AgreementType_Excel.DataType = ColumnDataType.ComboBox;
            AgreementType_Excel.ListItems = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Basis_DeviceTypeImportVM : BaseImportVM<Basis_DeviceTypeTemplateVM, Basis_DeviceType>
    {

    }

}
