using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_AnalysisAgVMs
{
    public partial class Basis_AnalysisAgTemplateVM : BaseTemplateVM
    {
        public ExcelPropety ADictionary_Excel = ExcelPropety.CreateProperty<Basis_AnalysisAg>(x => x.ADictionaryId);
        public ExcelPropety Device_Excel = ExcelPropety.CreateProperty<Basis_AnalysisAg>(x => x.DeviceId);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Basis_AnalysisAg>(x => x.TenantCode);

	    protected override void InitVM()
        {
            ADictionary_Excel.DataType = ColumnDataType.ComboBox;
            ADictionary_Excel.ListItems = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
            Device_Excel.DataType = ColumnDataType.ComboBox;
            Device_Excel.ListItems = DC.Set<Basis_Device>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Basis_AnalysisAgImportVM : BaseImportVM<Basis_AnalysisAgTemplateVM, Basis_AnalysisAg>
    {

    }

}
