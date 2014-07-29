using FSLL.MS.Core.DAL;
using FSLL.MS.Core.Service.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLL.MS.Core.Service
{
    public class MemberService : BaseService
    {
        private IRepository<userlogin> _loginRepo = null;
        private IRepository<vmember> _memberRepo = null;
        private IRepository<vmemberingroup> _memberGroupRepo = null;
        private IRepository<vrole> _roleRepo = null;

        IEnumerable<vrole> _membergrouproles = null;
        MemoryCacheManager _cacheManager = new MemoryCacheManager();

        public IEnumerable<vrole> Roles
        {
            get
            {
                _membergrouproles = _cacheManager.Get<List<vrole>>("membergrouproles");
                if (_membergrouproles == null)
                {
                    _membergrouproles = _roleRepo.All().ToList();
                    _cacheManager.Set("membergrouproles", _membergrouproles, 3600);
                }
                return _membergrouproles;
            }
        }

        public MemberService()
        {
            _memberRepo = new Repository<vmember>(_fsllDB);
            _memberGroupRepo = new Repository<vmemberingroup>(_fsllDB);
            _roleRepo = new Repository<vrole>(_fsllDB);
            _loginRepo = new Repository<userlogin>(_fsllDB);
        }

        public string Test()
        {
            var members = _fsllDB.vmembers.ToList();
            var member = _memberRepo.Find(c => c.ID == 1);

            return member.Name;

        }

        public int Login(string username, string password)
        {
            var member = _memberRepo.Find(c => c.MembershipNo == username);
            if (member != null)
            {
                var pwd = _loginRepo.Find(c => c.memberid == member.ID);
                if (pwd != null && pwd.password.Equals(password))
                {
                    return member.ID;
                }
            }

            return -1;
        }

        public bool IsAuthorized(string roles, int groupId, int memberId)
        {
            var _roles = _memberGroupRepo.Find(c => c.GroupID == groupId && c.ChurchMemberID == memberId);
            if (_roles == null)
                return false;

            var _userRoleIds = _roles.Roles.Split(',').Select(c => Convert.ToInt32(c)).ToList();


            var _allowRoleIds = roles.Split(',')
                                        .Select(c =>
                                            Roles.SingleOrDefault(o => o.MembershipRole == c).ID).ToList(); ;

            if (_userRoleIds.Intersect(_allowRoleIds).Count() > 0)
                return true;

            return false;
        }

        public bool IsAuthorized(string roles, int memberId)
        {
            var member = _memberRepo.Find(c => c.ID == memberId);
            if (member == null)
                return false;

            var rs = roles.Split(',');
            var _rids = new List<int>();
            foreach (var r in rs)
            {
                var role = Roles.SingleOrDefault(o => o.MembershipRole.Equals(r.ToString()));
                if (role != null)
                    _rids.Add(role.ID);
            }

            var groups = _memberGroupRepo.Filter(c => c.ChurchMemberID == member.ID);

            // var memberRoles = groups.Select(c => c.Roles.Split(',').ToList()).ToList();
            var _mids = new List<int>();
            foreach (var m in groups)
            {
                var tmp = m.Roles.Split(',');
                foreach (var r in tmp)
                {
                    _mids.Add(Convert.ToInt32(r));
                }
            }

            if (_mids.Distinct().Intersect(_rids).Count() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
