using FSLL.MS.Feedback.DAL;
using FSLL.MS.Feedback.Models;
using FSLLProxies.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Feedback.ModelExtensions
{
    public static class ServeEventModelExtension
    {

        public static requirement ToRequirement(this NewServeEventModel._RequirementModel model, MemberModel member)
        {
            if (model == null) return null;

            var entity = new requirement
            {
                ID = model.ID,
                IsPrivate = model.IsPrivate,
                MemberID = member.MemberID,
                MemberName = member.MemberName,
                RequirementTypeName = model.RequirementTypeName,
                Status = model.Status,
                Title = model.Title,
                Description = model.Description,

            };

            if (member.DefaultGroup != null)
            {
                entity.GroupID = member.DefaultGroup.GroupID;
                entity.GroupName = member.DefaultGroup.GroupName;
            }

            return entity;
        }

        public static serveeventfeedback ToServeEventFeedback(this NewServeEventModel._FeedbackModel model, int eventID, MemberModel target)
        {
            if (model == null) return null;

            var entity = new serveeventfeedback()
            {
                Feedback = model.Feedback,
                FromMemberID = model.FromMemberID,
                FromMemberName = model.From,
                ID = model.FeedbackID,
                TargetMemberID = target.MemberID,
                TargetMemberName = target.MemberName
            };

            entity.ServeEventID = eventID;

            return entity;
        }

        public static serveeventrequirement ToServeEventRequirement(this NewServeEventModel._RequirementModel model, int eventID, MemberModel target)
        {
            if (model == null)
                return null;
            
            var serveEventRequirement = new serveeventrequirement
            {
                Requirement = model.Title,
                RequirementDescription = model.Description,
                RequirementID = model.ID,
                ServeEventID = eventID,
                TargetMemberID = target.MemberID,
                TargetMemberName = target.MemberName
            };

            if (target.DefaultGroup != null)
            {
                serveEventRequirement.TargetMemberGroupID = target.DefaultGroup.GroupID;
                serveEventRequirement.TargetMemberGroupName = target.DefaultGroup.GroupName;
            }

            return serveEventRequirement;
        }
    }
}