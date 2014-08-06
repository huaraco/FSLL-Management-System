using FSLL.MS.Feedback.Common;
using FSLLProxies.Core.Clients;
using FSLLProxies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FSLL.MS.Feedback.Common.Extensions;

namespace FSLL.MS.Feedback.Controllers
{
    public class _TestController : BaseController
    {
        #region Test of calling web api

        [HttpGet]
        public IList<MemberModel> Test()
        {
            var CoreServiceUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["FSLLCoreServiceURL"];
            var getMembersUrl = string.Format("{0}/api/Account/ListAllMembers", CoreServiceUrl);
            var members = WebServiceManager.Get<IList<MemberModel>>(getMembersUrl);
            return members;
        }

        [HttpGet]
        public async Task<IList<MemberModel>> Test2()
        {
            using (var client = new AccountClient())
            {
                var response = await client.ListAllMembersAsync();
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<IList<MemberModel>>();
            }
        }

        [HttpGet]
        public object Test3()
        {
            var CoreServiceUrl = System.Web.Configuration.WebConfigurationManager.AppSettings["FSLLCoreServiceURL"];
            var getMembersUrl = string.Format("{0}/api/Account/ListAllMembers", CoreServiceUrl);
            var members = WebServiceManager.Get(getMembersUrl);
            return members;
        }

        [HttpGet]
        public async Task<IList<MemberModel>> Test4()
        {
            using (var client = new AccountClient())
            {
                return await client.ListAllMembersAsync().ToResult<IList<MemberModel>>();
            }
        }

        [HttpGet]
        public IList<MemberModel> Test5()
        {
            using (var client = new AccountClient())
            {
                return client.ListAllMembers().ToResult<IList<MemberModel>>();
            }
        }

        #endregion
    }
}
