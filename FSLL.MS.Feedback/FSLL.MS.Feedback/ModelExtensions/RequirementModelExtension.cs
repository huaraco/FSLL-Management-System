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
        public static requirement ToRequirementEntity(this RequirementModel model, int memberId, string memberName)
        {

            if (model == null) return null;

            var entity = new requirement
            {
                ID = model.ID,
                IsPrivate = model.IsPrivate,
                MemberID = memberId,
                MemberName = memberName,
                RequirementTypeName = model.RequirementTypeName,
                Status = model.Status,
                Title = model.Title,
                Description = model.Description,
                //GroupID = model.GroupID,
                //GroupName = model.GroupName
            };

            return entity;
        }
        public static dynamic To_RequirementModel(this requirement entity)
        {

            if (entity == null) return null;

            var model = new 
            {
                Description = entity.Description,
                ID = entity.ID,
                IsPrivate = entity.IsPrivate,
                RequirementTypeName = entity.RequirementTypeName,
                Title = entity.Title,
                Status = entity.Status,
                Date = entity.StartDate
            };

            return model;
        }

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
                Title = entity.Title,
                Status = entity.Status
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
                Group = group,
                Status = entity.Status
            };

            return model;
        }

        public static requirement ToRequirementEntity(this RequirementBasicModel model)
        {

            if (model == null) return null;

            var entity = new requirement
            {
                ID = model.ID,
                IsPrivate = model.IsPrivate,
                MemberID = model.MemberID,
                MemberName = model.MemberName,
                RequirementTypeName = model.RequirementTypeName,
                Status = model.Status,
                Title = model.Title,
                Description = model.Description,
                GroupID = model.GroupID,
                GroupName = model.GroupName
            };

            return entity;
        }

        public static requirement ToRequirementEntity(this RequirementDetailModel model)
        {
            if (model == null) return null;

            var entity = ((RequirementBasicModel)model).ToRequirementEntity();
            entity.StartDate = model.StartDate;
            entity.Remark = model.Remark;
            return entity;
        }

        



        public static DefaultRequirementModel ToDefaultRequirementModel(this app_requirementlist entity)
        {
            if (entity == null) return null;
            var model = new DefaultRequirementModel()
            {
                Description = entity.Description,
                ID = entity.ID,
                RequirementTypeName = entity.RequirementTypeName,
                Title = entity.Title
            };

            return model;
        }
    }
}