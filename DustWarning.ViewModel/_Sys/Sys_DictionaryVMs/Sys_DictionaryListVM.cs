using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_DictionaryVMs
{
    public partial class Sys_DictionaryListVM : BasePagedListVM<Sys_Dictionary_View, Sys_DictionarySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_Dictionary", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Sys"),
            };
        }


        protected override IEnumerable<IGridColumn<Sys_Dictionary_View>> InitGridHeader()
        {
            return new List<GridColumn<Sys_Dictionary_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Code),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Sys_Dictionary_View> GetSearchQuery()
        {
            var query = DC.Set<Sys_Dictionary>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.Code, x=>x.Code)
                .CheckContain(Searcher.TenantCode, x=>x.TenantCode)
                .CheckEqual(Searcher.ParentId, x=>x.ParentId)
                .Select(x => new Sys_Dictionary_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Code = x.Code,
                    TenantCode = x.TenantCode,
                    Name_view = x.Parent.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Sys_Dictionary_View : Sys_Dictionary{
        [Display(Name = "名称")]
        public String Name_view { get; set; }

    }
}
