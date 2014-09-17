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
        private Repository<app_requirementlist> _appRequirementRepo = null;

        public RequirementService()
        {
            _requirementRepo = new Repository<requirement>(_fsllDB);
            _appRequirementRepo = new Repository<app_requirementlist>(_fsllDB);
        }

        /// <summary>
        /// List Member Requirment by member ID
        /// </summary>
        /// <param name="memberId">member ID</param>
        /// <returns>member requirements</returns>
        public IList<requirement> ListMemberRequirement(int memberId)
        {
            return _requirementRepo.Filter(c => c.MemberID == memberId && !c.EndDate.HasValue).ToList();
        }

        /// <summary>
        /// List Member Requirment by member name
        /// </summary>
        /// <param name="memberName">member name</param>
        /// <returns>member requirements</returns>
        public IList<requirement> ListMemberRequirement(string memberName)
        {
            return _requirementRepo.Filter(c => c.MemberName == memberName && !c.EndDate.HasValue).ToList();
        }


        #region Default List
        
        
        public IList<app_requirementlist> ListDefaultRequirements()
        {
            return _appRequirementRepo.All().ToList();
        }

        #endregion


        public requirement NewMemberRequirement(requirement req)
        {
            try
            {
                var entity = _requirementRepo.Create(req);
                _fsllDB.SaveChanges();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateMemberRequirements(IList<requirement> requirements)
        {
            foreach (var req in requirements)
            {
                if (req.ID != 0)
                {

                }
            }

            throw new NotImplementedException();
        }



        public bool DeleteMemberRequirement(int reqId)
        {
            throw new NotImplementedException();
        }


        public bool DeleteMemberAllRequirements(int memberId)
        {
            throw new NotImplementedException();
        }

        private void addRequirement(requirement req)
        {
            _requirementRepo.Create(req);
            _fsllDB.SaveChanges();
        }

        public requirement UpdateMemberRequirement(requirement req)
        {
            var entity = req;
            if (req.ID == 0)
            {
                req.CreatedDate = DateTime.Now;
                entity =  NewMemberRequirement(req);
            }
            else
            {
                _requirementRepo.Update(req);
                _fsllDB.SaveChanges();
            }

            return entity;
        }




    }
}
