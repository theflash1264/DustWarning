using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Basis;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Basics.Basis_DetectionItmeVMs
{
    public partial class Basis_DetectionItmeListVM : BasePagedListVM<Basis_DetectionItme_View, Basis_DetectionItmeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_DetectionItme", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Basics"),
            };
        }


        protected override IEnumerable<IGridColumn<Basis_DetectionItme_View>> InitGridHeader()
        {
            return new List<GridColumn<Basis_DetectionItme_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Basis_DetectionItme_View> GetSearchQuery()
        {
            var query = DC.Set<Basis_DetectionItme>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.TenantCode, x=>x.TenantCode)
                .Select(x => new Basis_DetectionItme_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Code = x.Code,
                    Name_view = x.UDictionary.Name,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Basis_DetectionItme_View : Basis_DetectionItme{
        [Display(Name = "名称")]
        public String Name_view { get; set; }

    }
}
