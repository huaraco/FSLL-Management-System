using FSLL.MS.Core.Models;
using FSLL.MS.Core.Service;
using FSLL.MS.Core.ModelExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


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

        #region User Login

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

        #endregion

        #region Member and Group Functions
        
        /// <summary>
        /// List all church members
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<MemberModel> ListAllMembers()
        {
            return _memberService.ListAllMembers().Select(c => c.ToMemberModel());
        }

        /// <summary>
        /// List all the members of a certain group
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<MemberModel> ListMemberOfGroup(int groupid)
        {
            return _memberService.ListMembersByGroup(groupid).Select(c => c.ToMemberModel());
        }

        /// <summary>
        /// List all the groups of a member
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<GroupModel> ListMemberGroups(int memberId)
        {
            return _memberService.ListMemberGroups(memberId).Select(c => c.ToGroupModel());
        }

        /// <summary>
        /// Check whether members are from same cell group
        /// </summary>
        /// <param name="memberId1"></param>
        /// <param name="memberId2"></param>
        /// <returns></returns>
        [HttpGet]
        public bool IsInSameGroup(int memberId1, int memberId2)
        {
            return _memberService.IsInSameGroup(memberId1, memberId2);
        }

        /// <summary>
        /// Get Member by ID
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        [HttpGet]
        public MemberModel GetMember(int memberId)
        {
            return _memberService.GetMember(memberId).ToMemberModel(_memberService.ListMemberGroups(memberId));
        }
        #endregion
    }
}
