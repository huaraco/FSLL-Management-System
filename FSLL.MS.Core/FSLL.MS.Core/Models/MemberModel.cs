using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Core.Models
{
    public class MemberModel
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public string EnglishName { get; set; }
        public string AbstractName { get; set; }
        public GroupModel DefaultGroup { get; set; }
        public IList<GroupModel> Groups { get; set; }
    }

    public class GroupModel
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int GroupTypeID { get; set; }
        public string GroupTypeName { get; set; }
        public int ParentGroupID { get; set; }
        public string ParentGroupName { get; set; }
    }

    public class LoginModel
    {
        public string MembershipNo { get; set; }
        public string Password { get; set; }
        public bool IsRemeberMe { get; set; }
    }

    public class AuthorizedModel
    {
        public string Roles { get; set; }
        public int MemberID { get; set; }
        public int? GroupID { get; set; }
    }



}