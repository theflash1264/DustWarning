using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_AreaVMs
{
    public partial class Basis_AreaBatchVM : BaseBatchVM<Basis_Area, Basis_Area_BatchEdit>
    {
        public Basis_AreaBatchVM()
        {
            ListVM = new Basis_AreaListVM();
            LinkedVM = new Basis_Area_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Basis_Area_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
