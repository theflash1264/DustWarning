using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_NoticeVMs
{
    public partial class Business_NoticeListVM : BasePagedListVM<Business_Notice_View, Business_NoticeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Notice", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Business"),
            };
        }


        protected override IEnumerable<IGridColumn<Business_Notice_View>> InitGridHeader()
        {
            return new List<GridColumn<Business_Notice_View>>{
                this.MakeGridHeader(x => x.Title),
                this.MakeGridHeader(x => x.Content),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Business_Notice_View> GetSearchQuery()
        {
            var query = DC.Set<Business_Notice>()
                .CheckContain(Searcher.Title, x=>x.Title)
                .Select(x => new Business_Notice_View
                {
				    ID = x.ID,
                    Title = x.Title,
                    Content = x.Content,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Business_Notice_View : Business_Notice{

    }
}
