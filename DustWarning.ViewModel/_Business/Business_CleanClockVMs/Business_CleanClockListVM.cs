using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_CleanClockVMs
{
    public partial class Business_CleanClockListVM : BasePagedListVM<Business_CleanClock_View, Business_CleanClockSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_CleanClock", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Business"),
            };
        }


        protected override IEnumerable<IGridColumn<Business_CleanClock_View>> InitGridHeader()
        {
            return new List<GridColumn<Business_CleanClock_View>>{
                this.MakeGridHeader(x => x.CleanTime),
                this.MakeGridHeader(x => x.RecordName),
                this.MakeGridHeader(x => x.OperateName),
                this.MakeGridHeader(x => x.Situation),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Business_CleanClock_View> GetSearchQuery()
        {
            var query = DC.Set<Business_CleanClock>()
                .CheckBetween(Searcher.CleanTime?.GetStartTime(), Searcher.CleanTime?.GetEndTime(), x => x.CleanTime, includeMax: false)
                .CheckContain(Searcher.RecordName, x=>x.RecordName)
                .CheckContain(Searcher.OperateName, x=>x.OperateName)
                .Select(x => new Business_CleanClock_View
                {
				    ID = x.ID,
                    CleanTime = x.CleanTime,
                    RecordName = x.RecordName,
                    OperateName = x.OperateName,
                    Situation = x.Situation,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Business_CleanClock_View : Business_CleanClock{

    }
}
