using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DeviceTypeVMs
{
    public partial class Basis_DeviceTypeBatchVM : BaseBatchVM<Basis_DeviceType, Basis_DeviceType_BatchEdit>
    {
        public Basis_DeviceTypeBatchVM()
        {
            ListVM = new Basis_DeviceTypeListVM();
            LinkedVM = new Basis_DeviceType_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Basis_DeviceType_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
