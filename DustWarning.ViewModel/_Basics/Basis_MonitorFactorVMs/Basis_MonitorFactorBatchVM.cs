using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_MonitorFactorVMs
{
    public partial class Basis_MonitorFactorBatchVM : BaseBatchVM<Basis_MonitorFactor, Basis_MonitorFactor_BatchEdit>
    {
        public Basis_MonitorFactorBatchVM()
        {
            ListVM = new Basis_MonitorFactorListVM();
            LinkedVM = new Basis_MonitorFactor_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Basis_MonitorFactor_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
