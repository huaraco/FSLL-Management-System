using FSLL.MS.Feedback.Models;
using FSLL.MS.Feedback.Service;
using FSLL.MS.Feedback.ModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FSLL.MS.Feedback.Controllers
{
    public class FeedbackController : BaseController
    {
        private IFeedbackService _feedbackService = new FeedbackService();

        [HttpGet]
        public IEnumerable<FeedbackBasicModel> ListFeedbacks(int memberId)
        {
            return _feedbackService.GetLatestFeedback(memberId).Select(c=>c.ToFeedbackBasicModel());
        }
    }
}
