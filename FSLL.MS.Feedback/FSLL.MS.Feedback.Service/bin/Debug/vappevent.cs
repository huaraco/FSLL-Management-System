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
    
    public partial class vappevent
    {
        public int ID { get; set; }
        public string EventTitle { get; set; }
        public Nullable<System.TimeSpan> StartTime { get; set; }
        public Nullable<System.TimeSpan> EndTime { get; set; }
        public System.DateTime EventDate { get; set; }
        public bool IsRepeatable { get; set; }
        public int RepeatInterval { get; set; }
        public string Description { get; set; }
    }
}