using FSLL.MS.Feedback.Common;
using FSLL.MS.Feedback.Common.Constansts;
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

        private void init()
        {
            _requirementRepo = new Repository<requirement>(_fsllDB);
            _appRequirementRepo = new Repository<app_requirementlist>(_fsllDB);
        }

        public RequirementService()
        {
            init();
        }

        public RequirementService(int memberId)
            : base(memberId)
        {
            init();
        }

        /// <summary>
        /// List Member Requirment by member ID
        /// </summary>
        /// <param name="memberId">member ID</param>
        /// <returns>member requirements</returns>
        public IList<requirement> ListMemberRequirements(int memberId)
        {
            if (memberId == this._memberID)
            {
                //include private requirements
                return _requirementRepo.Filter(c =>
                            c.MemberID == memberId
                            && c.Status == FeedbackConstants.REQUIREMENT_STATUS_PENDING).ToList();
            }

            //public user
            return _requirementRepo.Filter(c =>
                    (!c.IsPrivate.HasValue || !c.IsPrivate.Value)
                    && c.MemberID == memberId
                    && c.Status == FeedbackConstants.REQUIREMENT_STATUS_PENDING).ToList();
        }

        /// <summary>
        /// List Member Requirment by member name
        /// </summary>
        /// <param name="memberName">member name</param>
        /// <returns>member requirements</returns>
        public IList<requirement> ListMemberRequirements(string memberName)
        {
            WebServiceManager _wsManager = new WebServiceManager("http://localhost/fsllCore");
            var members = _wsManager.Get("/Member/GetMember?name=" + memberName);

            if (members.Count > 0 && members[0]["MemberID"] != null)
            {
                return ListMemberRequirements(members[0].MemberID);
            }
            else
            {
                throw new Exception("Multiple Member Name Detected");
            }
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
                entity = NewMemberRequirement(req);
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
