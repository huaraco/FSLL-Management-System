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
        /// <summary>
        /// Get Events of Today
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        Task<IList<vappevent>> ListTodayEvents(int memberId = -1);
        //int[] ListEventGroups(int appEventID);

        /// <summary>
        /// Get event by event name and event date
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        serveevent GetServeEvent(string eventName, DateTime dt);

        serveevent NewServeEvent(serveevent serveEvent);
        bool DeleteServeEvent(serveevent serveEvent);
        bool DeleteServeEvent(int serveEventId);
        bool UpdateServeEvent(serveevent serveEvent);

        #region Serve Event From
        bool IsServeEventFromExist(int eventID, string fromName);
        void NewServeEventFrom(serveeventfrom from);
        #endregion

        #region Serve Event Target with Requirement
        void NewServeEventTarget(IList<serveeventrequirement> target);
        #endregion
    }
}
