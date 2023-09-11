using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_MonitorFactorVMs
{
    public partial class Basis_MonitorFactorListVM : BasePagedListVM<Basis_MonitorFactor_View, Basis_MonitorFactorSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_MonitorFactor", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Basics"),
            };
        }


        protected override IEnumerable<IGridColumn<Basis_MonitorFactor_View>> InitGridHeader()
        {
            return new List<GridColumn<Basis_MonitorFactor_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.MaxNum),
                this.MakeGridHeader(x => x.MinNum),
                this.MakeGridHeader(x => x.IsZeroAlarm),
                this.MakeGridHeader(x => x.ZeroAlarmDuration),
                this.MakeGridHeader(x => x.IsConstantAlarm),
                this.MakeGridHeader(x => x.ConstantAlarmDuration),
                this.MakeGridHeader(x => x.Sort),
                this.MakeGridHeader(x => x.IsShow),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Basis_MonitorFactor_View> GetSearchQuery()
        {
            var query = DC.Set<Basis_MonitorFactor>()
                .CheckEqual(Searcher.DeviceId, x=>x.DeviceId)
                .Select(x => new Basis_MonitorFactor_View
                {
				    ID = x.ID,
                    Name_view = x.Device.Name,
                    Name_view2 = x.MonitorFactor.Name,
                    MaxNum = x.MaxNum,
                    MinNum = x.MinNum,
                    IsZeroAlarm = x.IsZeroAlarm,
                    ZeroAlarmDuration = x.ZeroAlarmDuration,
                    IsConstantAlarm = x.IsConstantAlarm,
                    ConstantAlarmDuration = x.ConstantAlarmDuration,
                    Sort = x.Sort,
                    IsShow = x.IsShow,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Basis_MonitorFactor_View : Basis_MonitorFactor{
        [Display(Name = "设备名称")]
        public String Name_view { get; set; }
        [Display(Name = "名称")]
        public String Name_view2 { get; set; }

    }
}
