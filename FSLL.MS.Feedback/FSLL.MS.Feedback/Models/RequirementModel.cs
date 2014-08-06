using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSLLProxies.Core.Models;

namespace FSLL.MS.Feedback.Models
{
    /// <summary>
    /// Basic Member Requirement Infomation
    /// </summary>
    public class RequirementBasicModel
    {
        /// <summary>
        /// Requirement ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Requirement Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Requirment Type
        /// </summary>
        public string RequirementTypeName { get; set; }
        public string Description { get; set; }
        public string MemberName { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> GroupID { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
    }

    public class RequirementDetailModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string RequirementTypeName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Remark { get; set; }
        public string MemberName { get; set; }
        public Nullable<int> MemberID { get; set; }
        public MemberModel Member { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> GroupID { get; set; }
        public GroupModel Group { get; set; }
        public Nullable<bool> IsPrivate { get; set; }
    }
}