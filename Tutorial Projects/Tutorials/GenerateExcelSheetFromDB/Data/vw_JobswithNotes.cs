//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenerateExcelSheetFromDB.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_JobswithNotes
    {
        public int ID { get; set; }
        public string Pickup { get; set; }
        public string Destination { get; set; }
        public string PaxName { get; set; }
        public string PaxEmail { get; set; }
        public string PaxMobileNo { get; set; }
        public Nullable<int> NoOfPassengers { get; set; }
        public string Distance { get; set; }
        public string DurationMinutes { get; set; }
        public Nullable<double> Fare { get; set; }
        public Nullable<double> MeetandGreetCharges { get; set; }
        public Nullable<double> VehicleTypeCharges { get; set; }
        public Nullable<double> OtherCharges { get; set; }
        public Nullable<double> Discount { get; set; }
        public string JobStatus { get; set; }
        public string DateTimePickup { get; set; }
        public string DriverNo { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> DeletedFlag { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public string PaymentMethod { get; set; }
        public Nullable<int> VehicleRequiredID { get; set; }
        public Nullable<double> DirverComm { get; set; }
        public Nullable<bool> IsMG { get; set; }
        public string Notes { get; set; }
    }
}
