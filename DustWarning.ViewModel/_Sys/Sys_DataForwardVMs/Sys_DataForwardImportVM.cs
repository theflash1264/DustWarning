using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DataForwardVMs
{
    public partial class Sys_DataForwardTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Sys_DataForward>(x => x.Name);
        public ExcelPropety FType_Excel = ExcelPropety.CreateProperty<Sys_DataForward>(x => x.FTypeId);
        [Display(Name = "ip地址")]
        public ExcelPropety Ip_Excel = ExcelPropety.CreateProperty<Sys_DataForward>(x => x.Ip);
        [Display(Name = "端口")]
        public ExcelPropety Port_Excel = ExcelPropety.CreateProperty<Sys_DataForward>(x => x.Port);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Sys_DataForward>(x => x.TenantCode);

	    protected override void InitVM()
        {
            FType_Excel.DataType = ColumnDataType.ComboBox;
            FType_Excel.ListItems = DC.Set<Sys_Dictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Sys_DataForwardImportVM : BaseImportVM<Sys_DataForwardTemplateVM, Sys_DataForward>
    {

    }

}
