using FSLLProxies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using FSLLProxies.Core.Clients;

namespace FSLL.MS.Feedback.Controllers
{
    public class BaseController : ApiController
    {
        private int _currentMemberID;
        private FSLLProxies.Core.Models.MemberModel _currentChurchMember;

        public int CurrentMemberID
        {
            get
            {
                if (_currentMemberID == 0)
                {
                    if (HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
                        _currentMemberID = Convert.ToInt16(HttpContext.Current.User.Identity.Name);
                    else
                        _currentMemberID = -1;
                }
                return _currentMemberID;
            }

            set
            {
                _currentMemberID = value;

            }
        }

        protected async Task<MemberModel> CurrentChurchMember()
        {
            try
            {
                if (CurrentMemberID != 0)
                {
                    var client = new AccountClient();
                    var response = await client.GetMemberAsync(CurrentMemberID);
                    response.EnsureSuccessStatusCode();
                    _currentChurchMember = await response.Content.ReadAsAsync<MemberModel>();
                }

                return _currentChurchMember;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}