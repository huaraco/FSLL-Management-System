using FSLL.MS.Feedback.DAL;
using FSLL.MS.Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSLL.MS.Feedback.ModelExtensions
{
    public static class FeedbackModelExtension
    {
        public static FeedbackBasicModel ToFeedbackBasicModel(this serveeventfeedback entity)
        {
            if (entity == null) return null;
            var model = new FeedbackBasicModel()
            {
                Feedback = entity.Feedback,
                FeedbackID = entity.ID,
                
                From = entity.FromMemberName,
                Target = entity.TargetMemberName,    
            };
            if (entity.FromMemberID.HasValue)
                model.FromMemberID = entity.FromMemberID.Value;

            if (entity.TargetMemberID.HasValue)
                model.TargetMemberID = entity.TargetMemberID.Value;

            if (entity.CreatedDate.HasValue)
                model.FeedbackOn = entity.CreatedDate.Value;

            return model;
        }

        

        public static serveeventfeedback ToServeEventFeedback(this FeedbackBasicModel model, int eventID)
        {
            if (model == null) return null;
            var entity = new serveeventfeedback()
            {
                Feedback = model.Feedback,
                FromMemberID = model.FromMemberID,
                FromMemberName = model.From,
                ID = model.FeedbackID,
                TargetMemberID = model.TargetMemberID,
                TargetMemberName = model.Target,
            };

            entity.ServeEventID = eventID;

            return entity;
        }

        
    }
}