//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FSLL.MS.Feedback.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class serveeventfeedback
    {
        public int ID { get; set; }
        public Nullable<int> ServeEventID { get; set; }
        public string TargetMemberName { get; set; }
        public Nullable<int> TargetMemberID { get; set; }
        public string FromMemberName { get; set; }
        public Nullable<int> FromMemberID { get; set; }
        public string Feedback { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}
