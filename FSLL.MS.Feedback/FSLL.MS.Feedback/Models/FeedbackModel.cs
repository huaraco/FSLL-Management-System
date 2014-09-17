using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Feedback.Models
{
    public class _FeedbackModel
    {
        public int FeedbackID { get; set; }
        public string From { get; set; }
        public int FromMemberID { get; set; }
        public string Feedback { get; set; }
        public bool IsNew { get; set; }
    }

    public class FeedbackBasicModel
    {
        public int FeedbackID { get; set; }
        public string From { get; set; }
        public int FromMemberID { get; set; }
        public string Target { get; set; }
        public int TargetMemberID { get; set; }

        public string Feedback { get; set; }
        public DateTime FeedbackOn { get; set; }
        
    }

}