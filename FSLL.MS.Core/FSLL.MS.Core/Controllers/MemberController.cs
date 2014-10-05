using FSLL.MS.Core.Models;
using FSLL.MS.Core.ModelExtensions;
using FSLL.MS.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FSLL.MS.Core.Controllers
{
    public class MemberController : BaseController
    {
        private MemberService _memberService;
        public MemberController()
        {
            _memberService = new MemberService();
        }

        public MemberModel GetMember(int id)
        {
            return _memberService.GetMember(id).ToMemberModel();
        }

        /// <summary>
        /// Get Member By Name, if more than one member has the same name, will return null
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MemberModel GetMember(string name)
        {
            try
            {
                var members = _memberService.GetMember(name).Select(c => c.ToMemberModel());
                if (members.Count() == 1)
                    return members.First();

                return null;
            }
            catch
            {
                throw new Exception("Connection failed");
            }
        }

        public IEnumerable<MemberModel> ListMembers()
        {
            return _memberService.ListMembers().Select(c=>c.ToMemberModel());
        }

        public IEnumerable<MemberModel> ListMembers(int groupID)
        {
            return _memberService.ListMembers(groupID).Select(c => c.ToMemberModel());
        }
    }
}
