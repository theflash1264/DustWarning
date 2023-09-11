using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_AreaDictionaryVMs
{
    public partial class Sys_AreaDictionaryTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Sys_AreaDictionary>(x => x.Name);
        [Display(Name = "区域代码")]
        public ExcelPropety AreaCode_Excel = ExcelPropety.CreateProperty<Sys_AreaDictionary>(x => x.AreaCode);
        [Display(Name = "_Admin.Parent")]
        public ExcelPropety Parent_Excel = ExcelPropety.CreateProperty<Sys_AreaDictionary>(x => x.ParentId);

	    protected override void InitVM()
        {
            Parent_Excel.DataType = ColumnDataType.ComboBox;
            Parent_Excel.ListItems = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Sys_AreaDictionaryImportVM : BaseImportVM<Sys_AreaDictionaryTemplateVM, Sys_AreaDictionary>
    {

    }

}
