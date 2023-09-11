using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DeviceVMs
{
    public partial class Basis_DeviceListVM : BasePagedListVM<Basis_Device_View, Basis_DeviceSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Basics", dialogWidth: 800),
                this.MakeStandardAction("Basis_Device", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Basics"),
            };
        }


        protected override IEnumerable<IGridColumn<Basis_Device_View>> InitGridHeader()
        {
            return new List<GridColumn<Basis_Device_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Name_view2),
                this.MakeGridHeader(x => x.Place),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Basis_Device_View> GetSearchQuery()
        {
            var query = DC.Set<Basis_Device>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckEqual(Searcher.DTId, x=>x.DTId)
                .CheckEqual(Searcher.AreaId, x=>x.AreaId)
                .CheckContain(Searcher.Place, x=>x.Place)
                .CheckContain(Searcher.TenantCode, x=>x.TenantCode)
                .Select(x => new Basis_Device_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Code = x.Code,
                    Name_view = x.DT.Name,
                    Name_view2 = x.Area.Name,
                    Place = x.Place,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Basis_Device_View : Basis_Device{
        [Display(Name = "类别名称")]
        public String Name_view { get; set; }
        [Display(Name = "名称")]
        public String Name_view2 { get; set; }

    }
}
