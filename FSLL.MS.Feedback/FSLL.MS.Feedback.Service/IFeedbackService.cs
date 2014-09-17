using FSLL.MS.Feedback.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLL.MS.Feedback.Service
{
    public interface IFeedbackService
    {
        IEnumerable<serveeventfeedback> GetLatestFeedback(int memberId);
        serveeventfeedback NewFeedback(serveeventfeedback feedback);
    }
}
