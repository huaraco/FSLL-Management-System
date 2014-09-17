using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLL.MS.Feedback.Models
{
    public class ServeEventModel
    {
        public int AppEventID { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
    }

    public class NewServeEventModel
    {
        public string Title { get; set; }
        public _MemberModel Target { get; set; }
        public IList<_MemberModel> Froms { get; set; }

        public IList<_RequirementModel> Requirements { get; set; }
        public IList<_FeedbackModel> Feedbacks { get; set; }

        public class _RequirementModel : FSLL.MS.Feedback.Models.RequirementModel
        {
        }
        public class _MemberModel
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public string Type { get; set; }
        }
        public class _FeedbackModel : FSLL.MS.Feedback.Models._FeedbackModel
        {

        }
    }

    

    
}
