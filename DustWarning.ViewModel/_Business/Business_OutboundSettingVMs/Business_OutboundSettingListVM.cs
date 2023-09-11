using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_OutboundSettingVMs
{
    public partial class Business_OutboundSettingListVM : BasePagedListVM<Business_OutboundSetting_View, Business_OutboundSettingSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.BatchEdit, Localizer["Sys.BatchEdit"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "_Business", dialogWidth: 800),
                this.MakeStandardAction("Business_OutboundSetting", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "_Business"),
            };
        }


        protected override IEnumerable<IGridColumn<Business_OutboundSetting_View>> InitGridHeader()
        {
            return new List<GridColumn<Business_OutboundSetting_View>>{
                this.MakeGridHeader(x => x.IsCall),
                this.MakeGridHeader(x => x.EcName),
                this.MakeGridHeader(x => x.ApId),
                this.MakeGridHeader(x => x.SecretKey),
                this.MakeGridHeader(x => x.Sign),
                this.MakeGridHeader(x => x.Username),
                this.MakeGridHeader(x => x.ApiKey),
                this.MakeGridHeader(x => x.EntId),
                this.MakeGridHeader(x => x.RobotNum),
                this.MakeGridHeader(x => x.OutCallers),
                this.MakeGridHeader(x => x.CreateBy),
                this.MakeGridHeader(x => x.CreateUser),
                this.MakeGridHeader(x => x.SurplusAmount),
                this.MakeGridHeader(x => x.UnitPrice),
                this.MakeGridHeader(x => x.CallInterval),
                this.MakeGridHeader(x => x.TenantCode),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Business_OutboundSetting_View> GetSearchQuery()
        {
            var query = DC.Set<Business_OutboundSetting>()
                .Select(x => new Business_OutboundSetting_View
                {
				    ID = x.ID,
                    IsCall = x.IsCall,
                    EcName = x.EcName,
                    ApId = x.ApId,
                    SecretKey = x.SecretKey,
                    Sign = x.Sign,
                    Username = x.Username,
                    ApiKey = x.ApiKey,
                    EntId = x.EntId,
                    RobotNum = x.RobotNum,
                    OutCallers = x.OutCallers,
                    CreateBy = x.CreateBy,
                    CreateUser = x.CreateUser,
                    SurplusAmount = x.SurplusAmount,
                    UnitPrice = x.UnitPrice,
                    CallInterval = x.CallInterval,
                    TenantCode = x.TenantCode,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Business_OutboundSetting_View : Business_OutboundSetting{

    }
}
