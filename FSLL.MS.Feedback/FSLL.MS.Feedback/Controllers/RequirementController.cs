using FSLL.MS.Feedback.Models;
using FSLL.MS.Feedback.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FSLL.MS.Feedback.ModelExtensions;

namespace FSLL.MS.Feedback.Controllers
{
    public class RequirementController : BaseController
    {
        IRequirementService _reqService = new RequirementService();

        /// <summary>
        /// Get the requirments of a member
        /// </summary>
        /// <param name="memberId">member id</param>
        /// <returns>the requirment list</returns>
        [HttpGet]
        public IEnumerable<RequirementBasicModel> ListMemberRequirements(int memberId){
            return _reqService.ListMemberRequirement(memberId).Select(c=>c.ToRequirementBasicModel());
        }
    }
}
