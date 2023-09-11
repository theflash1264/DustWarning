using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DeviceVMs
{
    public partial class Basis_DeviceSearcher : BaseSearcher
    {
        [Display(Name = "设备名称")]
        public String Name { get; set; }
        [Display(Name = "设备编号")]
        public String Code { get; set; }
        public List<ComboSelectListItem> AllDTs { get; set; }
        public Guid? DTId { get; set; }
        public List<ComboSelectListItem> AllAreas { get; set; }
        public Guid? AreaId { get; set; }
        [Display(Name = "位置备注")]
        public String Place { get; set; }
        public String TenantCode { get; set; }

        protected override void InitVM()
        {
            AllDTs = DC.Set<Basis_DeviceType>().GetSelectListItems(Wtm, y => y.Name);
            AllAreas = DC.Set<Basis_Area>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
