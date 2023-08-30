using Mohashan.UserManager.Application.Responses;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;

public class CreateFeatureCommandResponse : BaseResponse<CreateFeatureResponseDto>
{
    public CreateFeatureCommandResponse() : base()
    {
    }

    public CreateFeatureCommandResponse(CreateFeatureResponseDto createFeatureResponse) : base(createFeatureResponse)
    {
    }
}