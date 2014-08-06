using FSLLProxies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Feedback.Models
{

    public class LoginViewModel
    {
        public string MembershipNo { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
    }

    public class MemberRequirementModel : MemberModel
    {
        public IList<RequirementBasicModel> Requirements { get; set; }
    }

}