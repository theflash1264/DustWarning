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


namespace DustWarning.ViewModel._Basics.Basis_AnalysisAgVMs
{
    public partial class Basis_AnalysisAgListVM : BasePagedListVM<Basis_AnalysisAg_View, Basis_AnalysisAgSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_AnalysisAg", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Basics"),
            };
        }


        protected override IEnumerable<IGridColumn<Basis_AnalysisAg_View>> InitGridHeader()
        {
            return new List<GridColumn<Basis_AnalysisAg_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Basis_AnalysisAg_View> GetSearchQuery()
        {
            var query = DC.Set<Basis_AnalysisAg>()
                .CheckEqual(Searcher.ADictionaryId, x=>x.ADictionaryId)
                .CheckEqual(Searcher.DeviceId, x=>x.DeviceId)
                .CheckContain(Searcher.TenantCode, x=>x.TenantCode)
                .Select(x => new Basis_AnalysisAg_View
                {
				    ID = x.ID,
                    Name_view = x.ADictionary.Name,
                    Name_view2 = x.Device.Name,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Basis_AnalysisAg_View : Basis_AnalysisAg{
        [Display(Name = "名称")]
        public String Name_view { get; set; }
        [Display(Name = "设备名称")]
        public String Name_view2 { get; set; }

    }
}
