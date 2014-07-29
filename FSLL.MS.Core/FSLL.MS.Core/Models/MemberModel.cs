using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Core.Models
{
    public class MemberModel
    {
        
    }

    public class LoginModel
    {
        public string MembershipNo { get; set; }
        public string Password{ get; set; }
        public bool IsRemeberMe { get; set; }
    }

    public class AuthorizedModel
    {
        public string Roles { get; set; }
        public int MemberID { get; set; }
        public int? GroupID { get; set; }
    }
}