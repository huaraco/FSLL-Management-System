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
    
    public partial class footprint
    {
        public int ID { get; set; }
        public string ActionType { get; set; }
        public string Action { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string MemberName { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
    }
}
