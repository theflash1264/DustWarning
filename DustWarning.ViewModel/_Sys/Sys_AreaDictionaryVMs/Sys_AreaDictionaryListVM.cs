using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Sys;


namespace DustWarning.ViewModel._Sys.Sys_AreaDictionaryVMs
{
    public partial class Sys_AreaDictionaryListVM : BasePagedListVM<Sys_AreaDictionary_View, Sys_AreaDictionarySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Sys", dialogWidth: 800),
                this.MakeStandardAction("Sys_AreaDictionary", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Sys"),
            };
        }


        protected override IEnumerable<IGridColumn<Sys_AreaDictionary_View>> InitGridHeader()
        {
            return new List<GridColumn<Sys_AreaDictionary_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.AreaCode),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Sys_AreaDictionary_View> GetSearchQuery()
        {
            var query = DC.Set<Sys_AreaDictionary>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.AreaCode, x=>x.AreaCode)
                .CheckEqual(Searcher.ParentId, x=>x.ParentId)
                .Select(x => new Sys_AreaDictionary_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    AreaCode = x.AreaCode,
                    Name_view = x.Parent.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Sys_AreaDictionary_View : Sys_AreaDictionary{
        [Display(Name = "名称")]
        public String Name_view { get; set; }

    }
}
