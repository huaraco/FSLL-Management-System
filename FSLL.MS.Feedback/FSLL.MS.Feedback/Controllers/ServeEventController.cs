using FSLL.MS.Feedback.DAL;
using FSLL.MS.Feedback.Models;
using FSLL.MS.Feedback.ModelExtensions;
using FSLL.MS.Feedback.Common.Extensions;

using FSLL.MS.Feedback.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FSLLProxies.Core.Models;
using FSLL.MS.Feedback.Common.Constansts;

namespace FSLL.MS.Feedback.Controllers
{
    public class ServeEventController : BaseController
    {
        IEventService _eventService = new EventService();
        IRequirementService _reqService = new RequirementService();
        IFeedbackService _feedbackService = new FeedbackService();

        /// <summary>
        /// Get the most matched Event Title
        /// </summary>
        /// <returns>Event title or Current Date</returns>
        [HttpGet]
        public async Task<string> ListTodayEvent()
        {
            var events = await _eventService.ListTodayEvents(CurrentMemberID);
            if (events.Count > 0)
            {
                var tmp = events.Where(c => c.StartTime.Value < DateTime.Now.TimeOfDay && c.EndTime.Value > DateTime.Now.TimeOfDay).FirstOrDefault();
                if (tmp != null) return tmp.EventTitle;

                return events.First().EventTitle;
            }
            return DateTime.Now.ToShortDateString();
        }

        /// <summary>
        /// Create New Serve Event with requirement
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public void NewServeEvent(NewServeEventModel model)
        {
            try
            {
                //Prepare Event Information
                var eventName = model.Title;
                var sEvent = _eventService.GetServeEvent(eventName, DateTime.Today);
                if (sEvent == null)
                {
                    sEvent = _eventService.NewServeEvent(new serveevent() { Title = model.Title, StartDateTime = DateTime.Now });
                }

                //Get Member Information
                var client = new FSLLProxies.Core.Clients.AccountClient();
                var targetMember = client.GetMember(model.Target.ID).ToResult<FSLLProxies.Core.Models.MemberModel>();
                if (targetMember == null)
                {
                    targetMember = new MemberModel()
                    {
                        MemberName = model.Target.Name
                    };
                }

                //Update Member Requirements
                UpdateMemberRequirements(model.Requirements, targetMember);

                //Update Feedback
                UpdateServeEventFeedback(model.Feedbacks, sEvent.ID, targetMember);

                //Update Event From list
                UpdateServeEventFrom(model.Froms, sEvent.ID);

                //Update Event Target list
                UpdateServeEventTarget(model.Requirements, sEvent.ID, targetMember);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Update Member Requirements
        private void UpdateMemberRequirements(IList<NewServeEventModel._RequirementModel> reqs, MemberModel member)
        {
            foreach (var r in reqs)
            {
                var req = r.ToRequirementEntity(member.MemberID, member.MemberName);
                req.StartDate = DateTime.Now;
                var entity = _reqService.UpdateMemberRequirement(req);
                r.ID = entity.ID;
            }
        }

        
        private void UpdateServeEventFeedback(IList<NewServeEventModel._FeedbackModel> feedbacks, int eventID, MemberModel target)
        {
            foreach (var f in feedbacks)
            {
                if (f.IsNew) _feedbackService.NewFeedback(f.ToServeEventFeedback(eventID, target));
            }
        }

        private void UpdateServeEventFrom(IList<NewServeEventModel._MemberModel> froms, int eventID)
        {
            var client = new FSLLProxies.Core.Clients.AccountClient();

            foreach (var f in froms)
            {
                if (_eventService.IsServeEventFromExist(eventID, f.Name))
                    continue;

                var eventFrom = new serveeventfrom();
                eventFrom.ServeEventID = eventID;

                if (f.Type == FeedbackConstants.SERVE_EVENT_MEMBER_TYPE_GROUP)
                {
                    eventFrom.GroupID = f.ID;
                    eventFrom.GroupName = f.Name;
                }
                else
                {
                    var member = client.GetMember(f.ID).ToResult<MemberModel>();
                    
                    if (member != null)
                    {
                        eventFrom.MemberID = f.ID;
                        eventFrom.MemberName = f.Name;
                        
                        if (member.DefaultGroup != null)
                        {
                            eventFrom.GroupName = member.DefaultGroup.GroupName;
                            eventFrom.GroupID = member.DefaultGroup.GroupID;
                        }
                    }
                    else
                        eventFrom.MemberName = f.Name;

                }

                _eventService.NewServeEventFrom(eventFrom);
            }
        }

        private void UpdateServeEventTarget(IList<NewServeEventModel._RequirementModel> reqs, int eventID, MemberModel target)
        {
            var targetRequirements = new List<serveeventrequirement>();
            foreach (var r in reqs)
            {
                targetRequirements.Add(r.ToServeEventRequirement(eventID, target));
            }

            _eventService.NewServeEventTarget(targetRequirements);
        }
    }
}
