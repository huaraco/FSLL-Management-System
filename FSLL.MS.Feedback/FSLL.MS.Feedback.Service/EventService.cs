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

namespace FSLL.MS.Feedback.Service
{
    public class EventService : BaseService, IEventService
    {

        Repository<vappevent> _appEventRepo = null;
        Repository<vappeventconfig> _appEventConfigRepo = null;

        public EventService()
        {
            _appEventRepo = new Repository<vappevent>(_fsllDB);
            _appEventConfigRepo = new Repository<vappeventconfig>(_fsllDB);
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


    }
}
