//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crud2_ADONet.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarType
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Nullable<int> NoOfPeople { get; set; }
        public Nullable<byte> LargeSuitecase { get; set; }
        public Nullable<byte> MediumSuitecase { get; set; }
        public Nullable<bool> WheelChairAccessible { get; set; }
        public string PercentIncreament { get; set; }
        public byte[] VehImage { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public byte[] UpdatedBy { get; set; }
        public Nullable<bool> DeletedFlag { get; set; }
    }
}
