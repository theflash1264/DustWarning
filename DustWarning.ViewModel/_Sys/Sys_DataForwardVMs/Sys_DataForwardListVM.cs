using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DataForwardVMs
{
    public partial class Sys_DataForwardListVM : BasePagedListVM<Sys_DataForward_View, Sys_DataForwardSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_DataForward", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Sys"),
            };
        }


        protected override IEnumerable<IGridColumn<Sys_DataForward_View>> InitGridHeader()
        {
            return new List<GridColumn<Sys_DataForward_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Ip),
                this.MakeGridHeader(x => x.Port),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Sys_DataForward_View> GetSearchQuery()
        {
            var query = DC.Set<Sys_DataForward>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.FTypeId, x=>x.FTypeId)
                .CheckContain(Searcher.Ip, x=>x.Ip)
                .CheckContain(Searcher.Port, x=>x.Port)
                .CheckContain(Searcher.TenantCode, x=>x.TenantCode)
                .Select(x => new Sys_DataForward_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Name_view = x.FType.Name,
                    Ip = x.Ip,
                    Port = x.Port,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Sys_DataForward_View : Sys_DataForward{
        [Display(Name = "名称")]
        public String Name_view { get; set; }

    }
}
