using System.ComponentModel.DataAnnotations.Schema;
using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest : BaseEntity
{

    #region Notes

    //this way, we can implement inner join statement uisng entityframework
    //even no relationship was made in the database level
    //we can implement it on the application side

    [ForeignKey("LeaveTypeId")]
    public LeaveType? LeaveType { get; set;}
    public int LeaveTypeId { get; set; }

    #endregion

    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    public string RequestingEmployeeId { get; set; }   = string.Empty;
}