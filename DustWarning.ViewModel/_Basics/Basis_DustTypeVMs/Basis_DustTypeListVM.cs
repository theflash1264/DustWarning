using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DustTypeVMs
{
    public partial class Basis_DustTypeListVM : BasePagedListVM<Basis_DustType_View, Basis_DustTypeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DustType", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Basics"),
            };
        }


        protected override IEnumerable<IGridColumn<Basis_DustType_View>> InitGridHeader()
        {
            return new List<GridColumn<Basis_DustType_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Basis_DustType_View> GetSearchQuery()
        {
            var query = DC.Set<Basis_DustType>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.TenantCode, x=>x.TenantCode)
                .Select(x => new Basis_DustType_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Basis_DustType_View : Basis_DustType{

    }
}
