using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveReques;

public class DeleteLeaveRequestCommand : IRequest
{
   public int Id { get; set; }
}
