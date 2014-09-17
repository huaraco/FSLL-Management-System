using FSLL.MS.Feedback.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLL.MS.Feedback.Service
{
    public interface IRequirementService
    {
        IList<requirement> ListMemberRequirement(int memberId);
        IList<requirement> ListMemberRequirement(string memberName);

        IList<app_requirementlist> ListDefaultRequirements();

        bool UpdateMemberRequirements(IList<requirement> requirements);
        requirement UpdateMemberRequirement(requirement req);
        requirement NewMemberRequirement(requirement req);
        bool DeleteMemberRequirement(int reqId);
        bool DeleteMemberAllRequirements(int memberId);
    }
}
