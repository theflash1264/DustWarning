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
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Business.Business_AlarmVMs
{
    public partial class Business_AlarmListVM : BasePagedListVM<Business_Alarm_View, Business_AlarmSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_Alarm", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Business"),
            };
        }


        protected override IEnumerable<IGridColumn<Business_Alarm_View>> InitGridHeader()
        {
            return new List<GridColumn<Business_Alarm_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.AlarmInformation),
                this.MakeGridHeader(x => x.StarTime),
                this.MakeGridHeader(x => x.EndTime),
                this.MakeGridHeader(x => x.Continued),
                this.MakeGridHeader(x => x.State),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Business_Alarm_View> GetSearchQuery()
        {
            var query = DC.Set<Business_Alarm>()
                .CheckEqual(Searcher.DeviceId, x=>x.DeviceId)
                .CheckEqual(Searcher.AlarmId, x=>x.AlarmId)
                .CheckEqual(Searcher.State, x=>x.State)
                .Select(x => new Business_Alarm_View
                {
				    ID = x.ID,
                    Name_view = x.Device.Name,
                    Name_view2 = x.Alarm.Name,
                    AlarmInformation = x.AlarmInformation,
                    StarTime = x.StarTime,
                    EndTime = x.EndTime,
                    Continued = x.Continued,
                    State = x.State,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Business_Alarm_View : Business_Alarm{
        [Display(Name = "设备名称")]
        public String Name_view { get; set; }
        [Display(Name = "名称")]
        public String Name_view2 { get; set; }

    }
}
