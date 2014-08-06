using FSLL.MS.Core.DAL;
using FSLL.MS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Core.ModelExtensions
{
    public static class MemberModelExtension
    {
        public static MemberModel ToMemberModel(this vmember entity)
        {
            if (entity == null) return null;

            var model = new MemberModel()
            {
                Email = entity.Email,
                MemberID = entity.ID,
                MemberName = entity.Name
            };

            return model;
        }

        public static MemberModel ToMemberModel(this vmember entity, IList<vmemberingroup> groupEntities)
        {
            if (entity == null) return null;

            var groups = new List<GroupModel>();

            foreach (var g in groupEntities)
            {
                groups.Add(g.ToGroupModel());
            }

            var model = new MemberModel()
            {
                Email = entity.Email,
                MemberID = entity.ID,
                MemberName = entity.Name,
                Groups = groups
            };

            return model;
        }

        public static GroupModel ToGroupModel(this vmemberingroup entity)
        {
            if (entity == null) return null;

            var model = new GroupModel()
            {
                GroupID = entity.GroupID,
                GroupName = entity.GroupName,
                GroupTypeID = entity.GroupTypeID,
                GroupTypeName = entity.GroupType,
            };

            return model;
        }
    }
}