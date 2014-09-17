using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSLL.MS.Feedback.DAL;
using System.Threading.Tasks;
using FSLLProxies.Core.Models;
using FSLLProxies.Core.Clients;
using System.Web;
using System.Net.Http;
using FSLL.MS.Feedback.Common.Extensions;
//using System.Data.Entity.Core.Objects;
//using System.Data.Entity;

namespace FSLL.MS.Feedback.Service
{
    public class EventService : BaseService, IEventService
    {

        Repository<vappevent> _appEventRepo = null;
        Repository<vappeventconfig> _appEventConfigRepo = null;
        Repository<serveevent> _serveEventRepo = null;
        Repository<serveeventfrom> _serveEventFromRepo = null;
        Repository<serveeventrequirement> _serveEventRequirementRepo = null;

        public EventService()
        {
            _appEventRepo = new Repository<vappevent>(_fsllDB);
            _appEventConfigRepo = new Repository<vappeventconfig>(_fsllDB);
            _serveEventRepo = new Repository<serveevent>(_fsllDB);
            _serveEventFromRepo = new Repository<serveeventfrom>(_fsllDB);
            _serveEventRequirementRepo = new Repository<serveeventrequirement>(_fsllDB);
        }

        public EventService(int memberId)
        {
            _appEventRepo = new Repository<vappevent>(_fsllDB);
            _appEventConfigRepo = new Repository<vappeventconfig>(_fsllDB);
            _serveEventRepo = new Repository<serveevent>(_fsllDB);
            _memberID = memberId;
        }


        public async Task<IList<vappevent>> ListTodayEvents(int memberId = -1)
        {
            try
            {
                var events = _appEventRepo.All().ToList().Where(c =>
                    (c.IsRepeatable && (c.EventDate - DateTime.Today).Days % c.RepeatInterval == 0) || c.EventDate == DateTime.Today);

                if (memberId != -1)
                {
                    var client = new AccountClient();
                    var member = await client.GetMemberAsync(memberId).ToResult<MemberModel>();

                    int[] groupIds = member.Groups.Select(c => c.GroupID).ToArray();

                    events = events.Where(c => ListEventGroups(c.ID).Intersect(groupIds).Count() > 0);
                }
                return events.ToList();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int[] ListEventGroups(int appEventID)
        {
            return _appEventConfigRepo.Filter(c => c.AppEventID == appEventID && c.Name == "Group").ToList()
                                        .Select(c => Convert.ToInt32(c.Value)).ToArray();
        }

        public serveevent GetServeEvent(string eventName, DateTime dt)
        {
            try
            {
                return _serveEventRepo.Find(c => c.Title == eventName
                                            && c.StartDateTime.Value.Year == dt.Year
                                            && c.StartDateTime.Value.Month == dt.Month
                                            && c.StartDateTime.Value.Day == dt.Day);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public serveevent NewServeEvent(serveevent serveEvent)
        {
            try
            {
                //serveEvent.
                var entity = _serveEventRepo.Create(serveEvent);
                _fsllDB.SaveChanges();
                return entity;
            }
            catch
            {
                return null;
            }

        }

        public bool DeleteServeEvent(serveevent serveEvent)
        {
            throw new NotImplementedException();
        }

        public bool DeleteServeEvent(int serveEventId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateServeEvent(serveevent serveEvent)
        {
            throw new NotImplementedException();
        }

        #region Serve Event From
        public bool IsServeEventFromExist(int eventID, string fromName)
        {
            try
            {
                return _serveEventFromRepo.Find(c => c.ServeEventID == eventID && c.MemberName == fromName) != null;
            }
            catch
            {
                throw;
            }
        }
        public void NewServeEventFrom(serveeventfrom from)
        {
            try
            {
                _serveEventFromRepo.Create(from);
                _fsllDB.SaveChanges();
            }
            catch { throw; }
        }
        #endregion

        #region Serve Event Target with Requirement
        public void NewServeEventTarget(IList<serveeventrequirement> targets)
        {
            foreach (var t in targets)
            {
                _serveEventRequirementRepo.Create(t);
            }
            _fsllDB.SaveChanges();
        }
        #endregion

    }
}
