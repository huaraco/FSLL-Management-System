using FSLL.MS.Feedback.DAL;
using FSLL.MS.Feedback.Models;
using FSLL.MS.Feedback.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FSLL.MS.Feedback.Controllers
{
    public class ServeEventController : BaseController
    {
        IEventService _eventService = new EventService();

        [HttpGet]
        public async Task<IList<vappevent>> ListTodayEvent()
        {
            var events =  await _eventService.ListTodayEvents(CurrentMemberID);
            return events;
        }
    }
}
