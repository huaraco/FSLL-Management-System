using FSLL.MS.Feedback.DAL;
using FSLL.MS.Feedback.Models;
using FSLLProxies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Feedback.ModelExtensions
{
    public static class RequirementModelExtension
    {
        public static RequirementBasicModel ToRequirementBasicModel(this requirement entity)
        {

            if (entity == null) return null;

            var model = new RequirementBasicModel()
            {
                Description = entity.Description,
                GroupID = entity.GroupID,
                GroupName = entity.GroupName,
                ID = entity.ID,
                IsPrivate = entity.IsPrivate,
                MemberID = entity.MemberID,
                MemberName = entity.MemberName,
                RequirementTypeName = entity.RequirementTypeName,
                Title = entity.Title
            };

            return model;
        }

        public static RequirementDetailModel ToRequirementDetailModel(this requirement entity, MemberModel member, GroupModel group)
        {

            if (entity == null) return null;

            var model = new RequirementDetailModel()
            {
                Description = entity.Description,
                GroupID = entity.GroupID,
                GroupName = entity.GroupName,
                ID = entity.ID,
                IsPrivate = entity.IsPrivate,
                MemberID = entity.MemberID,
                MemberName = entity.MemberName,
                RequirementTypeName = entity.RequirementTypeName,
                Title = entity.Title,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Remark = entity.Remark,
                Member = member,
                Group = group
            };
            
            return model;
        }
    }
}