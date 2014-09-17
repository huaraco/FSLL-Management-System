using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSLLProxies.Core.Models;

namespace FSLL.MS.Feedback.Models
{
    public class RequirementModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string RequirementTypeName { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
        public string Status { get; set; }
    }

    /// <summary>
    /// Basic requirement infomation with member information
    /// </summary>
    public class RequirementBasicModel : RequirementModel
    {
        public string MemberName { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> GroupID { get; set; }
    }

    public class RequirementDetailModel : RequirementBasicModel
    {
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Remark { get; set; }
        public MemberModel Member { get; set; }
        public GroupModel Group { get; set; }
    }

    public class DefaultRequirementModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RequirementTypeName { get; set; }
    }
}