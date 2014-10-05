using FSLL.MS.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSLL.MS.Core.Service
{
    public interface IMembershipService
    {
        string Test();

        int Login(string username, string password);

        bool IsAuthorized(string roles, int groupId, int memberId);

        bool IsAuthorized(string roles, int memberId);


        vmember GetMember(int memberId);

        IList<vmember> ListMembers();

        IList<vmember> ListMembers(int groupId);
        
        IList<vmemberingroup> ListMemberGroups(int memberId);
        
        bool IsInSameGroup(int memberId1, int memberId2);


        
        
    }
}
