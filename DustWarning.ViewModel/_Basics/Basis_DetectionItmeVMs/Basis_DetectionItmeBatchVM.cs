using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DetectionItmeVMs
{
    public partial class Basis_DetectionItmeBatchVM : BaseBatchVM<Basis_DetectionItme, Basis_DetectionItme_BatchEdit>
    {
        public Basis_DetectionItmeBatchVM()
        {
            ListVM = new Basis_DetectionItmeListVM();
            LinkedVM = new Basis_DetectionItme_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Basis_DetectionItme_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
