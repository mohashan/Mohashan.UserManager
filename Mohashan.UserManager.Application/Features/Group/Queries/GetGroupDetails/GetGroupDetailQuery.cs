using MediatR;
using Mohashan.UserManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Group.Queries.GetGroupDetails;

public class GetGroupDetailQuery:IRequest<GroupDetailVm>
{
    public Guid Id { get; set; }
}
