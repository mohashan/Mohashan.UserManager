using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.DeleteFeature;

public class DeleteFeatureCommand:IRequest
{
    public Guid Id { get; set; }
}
