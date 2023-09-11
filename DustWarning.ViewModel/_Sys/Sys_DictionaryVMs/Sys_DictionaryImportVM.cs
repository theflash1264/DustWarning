using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DictionaryVMs
{
    public partial class Sys_DictionaryTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Sys_Dictionary>(x => x.Name);
        [Display(Name = "编号")]
        public ExcelPropety Code_Excel = ExcelPropety.CreateProperty<Sys_Dictionary>(x => x.Code);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Sys_Dictionary>(x => x.TenantCode);
        [Display(Name = "_Admin.Parent")]
        public ExcelPropety Parent_Excel = ExcelPropety.CreateProperty<Sys_Dictionary>(x => x.ParentId);

	    protected override void InitVM()
        {
            Parent_Excel.DataType = ColumnDataType.ComboBox;
            Parent_Excel.ListItems = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Sys_DictionaryImportVM : BaseImportVM<Sys_DictionaryTemplateVM, Sys_Dictionary>
    {

    }

}
