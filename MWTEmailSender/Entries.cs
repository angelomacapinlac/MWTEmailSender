using System.ComponentModel.DataAnnotations;

namespace MissedWork.Models
{
    public class Entries
    {
        [Key]
        public long Id { get; set; }
        public string Priority { get; set; }
        public string GM_Id { get; set; }
        public string GM { get; set; }
        public string? District { get; set; }
        public string? ServiceArea { get; set; }
        public string? TimeZone { get; set; }
        public string? Province { get; set; }
        public string? JobType { get; set; }
        public long Call_Id { get; set; }
        public string Company { get; set; }
        public string Rebooked { get; set; }
        public string PrevMissed { get; set; }
        public DateTime EntryDate { get; set; }
       
        public string ForGM { get; set; }
        public long ReasonId { get; set; }
        public string? DetailedReason { get; set; }
        public string? GMCommentary { get; set; }
        public string? GMMitigationPlan { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string StepId { get; set; }
        public string AddedBy { get; set; }
        public string? EntryType { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? NewDueDate { get; set; }
        public string? OriginatingSystemWorkOrderGroupId { get; set; }
        public string OriginatingSystemWorkOrderId { get; set; }
        public string StatusCode { get; set; }
        public string? JobId{ get; set; }
        public string? IsCancelled{ get; set; }
        public string? CancelledBy{ get; set; }
        public string? AssignedTech { get; set; }
        public DateTime? TechSchedule { get; set; }
        public string? TechStatus { get; set; }
        public string? CancelledReason { get; set; }
    } 
}
