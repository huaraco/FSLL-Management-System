using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FSLL.MS.Core.Controllers
{
    public class BaseController : ApiController
    {
        private string _currentMembershipNo;
        
        public string CurrentMembershipNo
        {
            get
            {
                if (_currentMembershipNo == null)
                {
                    if (HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
                        _currentMembershipNo = HttpContext.Current.User.Identity.Name;
                    else
                        _currentMembershipNo = "Guest";
                }
                return _currentMembershipNo;
            }

            set
            {
                _currentMembershipNo = value;

            }
        }

    }
}
