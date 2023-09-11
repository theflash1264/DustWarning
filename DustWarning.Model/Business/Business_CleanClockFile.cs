using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DustWarning.Model.Business
{
    public class Business_CleanClockFile : TopBasePoco
    {
        public Business_CleanClock CleanClock { get; set; }
        [Display(Name = "打卡")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? CleanClockId { get; set; }

        public FileAttachment File { get; set; }
        [Display(Name = "附件")]
        [Required(ErrorMessage = "{0}是必填项")]
        public Guid? FileId { get; set; }
    }
}
