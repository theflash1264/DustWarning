using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_DetectionItmeVMs
{
    public partial class Basis_DetectionItmeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Basis_DetectionItme>(x => x.Name);
        [Display(Name = "编码")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<Basis_DetectionItme>(x => x.Code);
        public ExcelPropety UDictionary_Excel = ExcelPropety.CreateProperty<Basis_DetectionItme>(x => x.UDictionaryId);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Basis_DetectionItme>(x => x.TenantCode);

	    protected override void InitVM()
        {
            UDictionary_Excel.DataType = ColumnDataType.ComboBox;
            UDictionary_Excel.ListItems = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Basis_DetectionItmeImportVM : BaseImportVM<Basis_DetectionItmeTemplateVM, Basis_DetectionItme>
    {

    }

}
