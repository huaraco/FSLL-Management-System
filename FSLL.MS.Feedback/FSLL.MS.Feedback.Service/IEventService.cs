using FSLL.MS.Feedback.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLL.MS.Feedback.Service
{
    public interface IEventService
    {
        Task<IList<vappevent>> ListTodayEvents(int memberId = -1);
        //int[] ListEventGroups(int appEventID);
    }
}
