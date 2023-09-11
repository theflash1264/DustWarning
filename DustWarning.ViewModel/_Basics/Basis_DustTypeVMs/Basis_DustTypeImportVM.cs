using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DustTypeVMs
{
    public partial class Basis_DustTypeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "类别名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Basis_DustType>(x => x.Name);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Basis_DustType>(x => x.TenantCode);

	    protected override void InitVM()
        {
        }

    }

    public class Basis_DustTypeImportVM : BaseImportVM<Basis_DustTypeTemplateVM, Basis_DustType>
    {

    }

}
