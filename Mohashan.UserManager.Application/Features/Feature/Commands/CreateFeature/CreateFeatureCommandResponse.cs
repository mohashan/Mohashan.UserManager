using Mohashan.UserManager.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;

public class CreateFeatureCommandResponse:BaseResponse<CreateFeatureResponseDto>
{
    public CreateFeatureCommandResponse():base()
    {
        
    }
    public CreateFeatureCommandResponse(CreateFeatureResponseDto createFeatureResponse):base(createFeatureResponse)
    {
        
    }
}
