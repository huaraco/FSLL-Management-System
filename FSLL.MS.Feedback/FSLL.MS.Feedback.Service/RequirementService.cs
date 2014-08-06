using FSLL.MS.Feedback.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSLL.MS.Feedback.Service
{
    public class RequirementService : BaseService, IRequirementService
    {
        private Repository<requirement> _requirementRepo = null;

        public RequirementService()
        {
            _requirementRepo = new Repository<requirement>(_fsllDB);
        }

        public IList<requirement> ListMemberRequirement(int memberId)
        {
            return _requirementRepo.Filter(c => c.MemberID == memberId && !c.EndDate.HasValue).ToList();
        }


        public IList<requirement> ListMemberRequirement(string memberName)
        {
            return _requirementRepo.Filter(c => c.MemberName == memberName && !c.EndDate.HasValue).ToList();
        }
    }
}
