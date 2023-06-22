using MediatR;
using Mohashan.UserManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Feature.Queries.GetFeatureDetails;

public class GetFeatureDetailQuery : IRequest<FeatureDetailVm>
{
    public Guid Id { get; set; }
}
