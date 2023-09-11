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


namespace DustWarning.ViewModel._Basics.Basis_AreaVMs
{
    public partial class Basis_AreaListVM : BasePagedListVM<Basis_Area_View, Basis_AreaSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Area", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Basics"),
            };
        }


        protected override IEnumerable<IGridColumn<Basis_Area_View>> InitGridHeader()
        {
            return new List<GridColumn<Basis_Area_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.AreaCode),
                this.MakeGridHeader(x => x.Lng),
                this.MakeGridHeader(x => x.Lat),
                this.MakeGridHeader(x => x.Remarks),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.Name_view3),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Basis_Area_View> GetSearchQuery()
        {
            var query = DC.Set<Basis_Area>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.AreaCode, x=>x.AreaCode)
                .CheckContain(Searcher.TenantCode, x=>x.TenantCode)
                .Select(x => new Basis_Area_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    AreaCode = x.AreaCode,
                    Lng = x.Lng,
                    Lat = x.Lat,
                    Remarks = x.Remarks,
                    Name_view = x.Area.Name,
                    Name_view2 = x.Province.Name,
                    Name_view3 = x.City.Name,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Basis_Area_View : Basis_Area{
        [Display(Name = "名称")]
        public String Name_view { get; set; }
        [Display(Name = "名称")]
        public String Name_view2 { get; set; }
        [Display(Name = "名称")]
        public String Name_view3 { get; set; }

    }
}
