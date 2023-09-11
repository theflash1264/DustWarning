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
    public partial class Basis_DeviceBatchVM : BaseBatchVM<Basis_Device, Basis_Device_BatchEdit>
    {
        public Basis_DeviceBatchVM()
        {
            ListVM = new Basis_DeviceListVM();
            LinkedVM = new Basis_Device_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Basis_Device_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
