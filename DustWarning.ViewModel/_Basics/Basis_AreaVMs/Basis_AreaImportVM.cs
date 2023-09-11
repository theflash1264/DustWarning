using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_AreaVMs
{
    public partial class Basis_AreaTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.Name);
        [Display(Name = "区域编码")]
        public ExcelPropety AreaCode_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.AreaCode);
        [Display(Name = "经度")]
        public ExcelPropety Lng_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.Lng);
        [Display(Name = "纬度")]
        public ExcelPropety Lat_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.Lat);
        [Display(Name = "备注")]
        public ExcelPropety Remarks_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.Remarks);
        public ExcelPropety Area_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.AreaId);
        public ExcelPropety Province_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.ProvinceId);
        public ExcelPropety City_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.CityId);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Basis_Area>(x => x.TenantCode);

	    protected override void InitVM()
        {
            Area_Excel.DataType = ColumnDataType.ComboBox;
            Area_Excel.ListItems = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
            Province_Excel.DataType = ColumnDataType.ComboBox;
            Province_Excel.ListItems = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
            City_Excel.DataType = ColumnDataType.ComboBox;
            City_Excel.ListItems = DC.Set<Sys_AreaDictionary>().GetSelectListItems(Wtm, y => y.Name);
        }

    }

    public class Basis_AreaImportVM : BaseImportVM<Basis_AreaTemplateVM, Basis_Area>
    {

    }

}
