using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DustWarning.Model.Basis;


namespace DustWarning.ViewModel._Basics.Basis_AnalysisAgVMs
{
    public partial class Basis_AnalysisAgBatchVM : BaseBatchVM<Basis_AnalysisAg, Basis_AnalysisAg_BatchEdit>
    {
        public Basis_AnalysisAgBatchVM()
        {
            ListVM = new Basis_AnalysisAgListVM();
            LinkedVM = new Basis_AnalysisAg_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Basis_AnalysisAg_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
