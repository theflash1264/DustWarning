using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Business
{
    public class Business_OutboundSetting : TopBasePoco, ITenant
    {


        [Display(Name = "语音外呼总开关")]
        public bool IsCall { get; set; }

        [Display(Name = "企业名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string EcName { get; set; }

        [Display(Name = "账号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string ApId { get; set; }

        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string SecretKey { get; set; }

        [Display(Name = "签名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Sign { get; set; }

        [Display(Name = "用户姓名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Username { get; set; }

        [Display(Name = "密钥")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string ApiKey { get; set; }

        [Display(Name = "租户id")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string EntId { get; set; }

        [Display(Name = "机器人数量")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string RobotNum { get; set; }

        [Display(Name = "外显号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string OutCallers { get; set; }

        [Display(Name = "操作用户ID")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string CreateBy { get; set; }

        [Display(Name = "操作用户名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string CreateUser { get; set; }

        [Display(Name = "剩余金额")]
        [Required(ErrorMessage = "{0}是必填项")]
        public decimal SurplusAmount { get; set; }
        [Display(Name = "单价")]
        [Required(ErrorMessage = "{0}是必填项")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "报警外呼间隔时长")]
        public decimal CallInterval { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
