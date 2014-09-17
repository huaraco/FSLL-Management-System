using FSLL.MS.Feedback.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLL.MS.Feedback.Service
{
    public class FeedbackService : BaseService, IFeedbackService
    {
        Repository<serveeventfeedback> _feedbackRepo = null;

        public FeedbackService()
        {
            _feedbackRepo = new Repository<serveeventfeedback>(_fsllDB);
        }

        public IEnumerable<DAL.serveeventfeedback> GetLatestFeedback(int memberId)
        {
            var feedbacks = new List<serveeventfeedback>();
            var feeds = _feedbackRepo.Filter(c => c.TargetMemberID == memberId)
                            .OrderByDescending(c => c.CreatedDate).ToList()
                            .GroupBy(c => c.FromMemberName);

            return feeds.Select(c => c.FirstOrDefault());
        }


        public serveeventfeedback NewFeedback(serveeventfeedback feedback)
        {
            try
            {
                var entity = _feedbackRepo.Create(feedback);
                _fsllDB.SaveChanges();
                return entity;
            }
            catch
            {
                throw;
            }
        }
    }
}
