using DustWarning.Model.Sys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Basis
{
    public class Basis_Area : PersistPoco, ITenant
    {
        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "区域编码")]
        public string AreaCode { get; set; }
        [Display(Name = "经度")]
        public string Lng { get; set; }
        [Display(Name = "纬度")]
        public string Lat { get; set; }
        [Display(Name = "备注")]
        public string Remarks { get; set; }
        public Sys_AreaDictionary Area { get; set; }
        [Display(Name = "县")]
        public Guid? AreaId { get; set; }
        public Sys_AreaDictionary Province { get; set; }
        [Display(Name = "省")]
        public Guid? ProvinceId { get; set; }
        public Sys_AreaDictionary City { get; set; }
        [Display(Name = "市")]
        public Guid? CityId { get; set; }
        [Display(Name = "租户")]
        public string TenantCode { get; set; }
    }
}
