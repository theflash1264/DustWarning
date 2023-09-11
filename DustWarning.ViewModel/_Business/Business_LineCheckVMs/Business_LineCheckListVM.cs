using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Business;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Business.Business_LineCheckVMs
{
    public partial class Business_LineCheckListVM : BasePagedListVM<Business_LineCheck_View, Business_LineCheckSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_LineCheck", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Business"),
            };
        }


        protected override IEnumerable<IGridColumn<Business_LineCheck_View>> InitGridHeader()
        {
            return new List<GridColumn<Business_LineCheck_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.CheckTime),
                this.MakeGridHeader(x => x.Situation),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Business_LineCheck_View> GetSearchQuery()
        {
            var query = DC.Set<Business_LineCheck>()
                .CheckEqual(Searcher.DeviceId, x=>x.DeviceId)
                .CheckBetween(Searcher.CheckTime?.GetStartTime(), Searcher.CheckTime?.GetEndTime(), x => x.CheckTime, includeMax: false)
                .Select(x => new Business_LineCheck_View
                {
				    ID = x.ID,
                    Name_view = x.Device.Name,
                    Name_view2 = x.FrameworkUser.Name,
                    CheckTime = x.CheckTime,
                    Situation = x.Situation,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Business_LineCheck_View : Business_LineCheck{
        [Display(Name = "设备名称")]
        public String Name_view { get; set; }
        [Display(Name = "_Admin.Name")]
        public String Name_view2 { get; set; }

    }
}
