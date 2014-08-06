using FSLL.MS.Feedback.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Threading.Tasks;
using FSLLProxies.Core.Models;
using FSLL.MS.Feedback.Common;
using FSLLProxies.Core.Clients;
using FSLL.MS.Feedback.Common.Extensions;

namespace FSLL.MS.Feedback.Controllers
{
    public class AccountController : BaseController
    {
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Member Id</returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<int> Login(LoginViewModel model)
        {
            try
            {

                using (var client = new FSLLProxies.Core.Clients.AccountClient())
                {
                    var member = new LoginModel()
                    {
                        IsRemeberMe = model.IsRemember,
                        MembershipNo = model.MembershipNo,
                        Password = model.Password
                    };

                    var response = await client.LoginAsync(member);
                    response.EnsureSuccessStatusCode();
                    var memberId = await response.Content.ReadAsAsync<int>();

                    if (memberId != -1)
                    {
                        FormsAuthenticationTicket tkt;
                        string cookiestr;
                        HttpCookie ck;
                        tkt = new FormsAuthenticationTicket(1, memberId.ToString(), DateTime.Now, DateTime.Now.AddDays(30), true, "");

                        cookiestr = FormsAuthentication.Encrypt(tkt);
                        ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                        ck.Expires = tkt.Expiration;
                        if (Request.RequestUri.Host != "localhost")
                            ck.Domain = Request.RequestUri.Host;

                        ck.Path = FormsAuthentication.FormsCookiePath;
                        //System.Web.HttpContext.Current
                        HttpContext.Current.Response.Cookies.Add(ck);
                        return memberId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return -1;
        }

        /// <summary>
        /// Test Authorization
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<MemberModel> TestLogin()
        {
            return await CurrentChurchMember();
        }

        /// <summary>
        /// Log out
        /// </summary>
        [HttpGet]
        public void Logout()
        {
            HttpContext.Current.Session.Clear();
          //  HttpContext.Current.Response.Cookies.Clear();
          //  FormsAuthentication.SignOut();
        }


        

        //        [HttpPost]
        //        [FSLLAuthorize(Roles="领袖")]
        //        public vchurchmember GetMember()
        //        {
        //            var memberId = HttpContext.Current.User.Identity.Name;
        //            Repository<vchurchmember> _repo = new Repository<vchurchmember>(new fsll_attendanceEntities());
        //            var member = _repo.Find(c => c.ID.ToString() == memberId);
        //            return member;
        //        }

    }
}
