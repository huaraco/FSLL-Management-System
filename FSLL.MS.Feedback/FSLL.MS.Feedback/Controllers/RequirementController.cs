﻿using FSLL.MS.Feedback.Models;
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
        public IEnumerable<FSLL.MS.Feedback.Models.RequirementModel> ListMemberRequirements(int memberId)
        {
            return _reqService.ListMemberRequirement(memberId).Select(c=>c.To_RequirementModel());
        }

        [HttpGet]
        public IEnumerable<DefaultRequirementModel> ListDefaultRequirements()
        {
            return _reqService.ListDefaultRequirements().Select(c => c.ToDefaultRequirementModel());
        }
    }
}
