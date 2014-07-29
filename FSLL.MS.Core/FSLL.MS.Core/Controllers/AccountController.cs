using FSLL.MS.Core.Models;
using FSLL.MS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FSLL.MS.Core.Controllers
{
    /// <summary>
    /// Account Controller
    /// </summary>
    public class AccountController : BaseController
    {
        private MemberService _memberService = new MemberService();

        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Test()
        {
            return _memberService.Test();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public int Login(LoginModel model)
        {
            return _memberService.Login(model.MembershipNo, model.Password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public bool IsAuthorized(AuthorizedModel model)
        {
            if (model.GroupID.HasValue)
                return _memberService.IsAuthorized(model.Roles, model.GroupID.Value, model.MemberID);
            else
                return _memberService.IsAuthorized(model.Roles, model.MemberID);
        }

        
    }
}
