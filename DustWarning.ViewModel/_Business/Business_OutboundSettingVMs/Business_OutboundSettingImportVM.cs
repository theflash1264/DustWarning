using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Business;


namespace DustWarning.ViewModel._Business.Business_OutboundSettingVMs
{
    public partial class Business_OutboundSettingTemplateVM : BaseTemplateVM
    {
        [Display(Name = "语音外呼总开关")]
        public ExcelPropety IsCall_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.IsCall);
        [Display(Name = "企业名称")]
        public ExcelPropety EcName_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.EcName);
        [Display(Name = "账号")]
        public ExcelPropety ApId_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.ApId);
        [Display(Name = "密码")]
        public ExcelPropety SecretKey_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.SecretKey);
        [Display(Name = "签名")]
        public ExcelPropety Sign_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.Sign);
        [Display(Name = "用户姓名")]
        public ExcelPropety Username_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.Username);
        [Display(Name = "密钥")]
        public ExcelPropety ApiKey_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.ApiKey);
        [Display(Name = "租户id")]
        public ExcelPropety EntId_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.EntId);
        [Display(Name = "机器人数量")]
        public ExcelPropety RobotNum_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.RobotNum);
        [Display(Name = "外显号")]
        public ExcelPropety OutCallers_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.OutCallers);
        [Display(Name = "操作用户ID")]
        public ExcelPropety CreateBy_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.CreateBy);
        [Display(Name = "操作用户名")]
        public ExcelPropety CreateUser_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.CreateUser);
        [Display(Name = "剩余金额")]
        public ExcelPropety SurplusAmount_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.SurplusAmount);
        [Display(Name = "单价")]
        public ExcelPropety UnitPrice_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.UnitPrice);
        [Display(Name = "报警外呼间隔时长")]
        public ExcelPropety CallInterval_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.CallInterval);
        public ExcelPropety TenantCode_Excel = ExcelPropety.CreateProperty<Business_OutboundSetting>(x => x.TenantCode);

	    protected override void InitVM()
        {
        }

    }

    public class Business_OutboundSettingImportVM : BaseImportVM<Business_OutboundSettingTemplateVM, Business_OutboundSetting>
    {

    }

}
