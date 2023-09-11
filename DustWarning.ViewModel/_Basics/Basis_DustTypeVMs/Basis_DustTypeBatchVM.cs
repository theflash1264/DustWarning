using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_DustTypeVMs
{
    public partial class Basis_DustTypeBatchVM : BaseBatchVM<Basis_DustType, Basis_DustType_BatchEdit>
    {
        public Basis_DustTypeBatchVM()
        {
            ListVM = new Basis_DustTypeListVM();
            LinkedVM = new Basis_DustType_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Basis_DustType_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
