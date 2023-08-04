using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Infrastructure;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Exceptions;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;

public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, CreateFeatureCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Domain.Entities.Feature> _featureRepository;
    private readonly IEmailService _emailService;

    public CreateFeatureCommandHandler(IMapper mapper,
                                       IAsyncRepository<Domain.Entities.Feature> featureRepository,
                                       IEmailService emailService)
    {
        _mapper = mapper;
        _featureRepository = featureRepository;
        _emailService = emailService;
    }
    public async Task<CreateFeatureCommandResponse> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
    {
        CreateFeatureCommandResponse response = new CreateFeatureCommandResponse();
        var validator = new CreateFeatureCommandValidator();
        var validatorResult = validator.Validate(request);
        if (!validatorResult.IsValid)
        {
            response.ValidationErrors = validatorResult.Errors.Select(c=>c.ErrorMessage).ToList();
            response.Success = false;
            return response;
        }
        
        var feature = await _featureRepository.AddAsync(_mapper.Map<Domain.Entities.Feature>(request));

        var mail = new Models.Mail.Email
        {
            To = "msh200x@gmail.com",
            Subject = "Create New Feature",
            Body = $"New Feature for user manager is created with the name of {feature.Name}"
        };

        try
        {
            await _emailService.SendEmailAsync(mail);
        }
        catch (Exception ex)
        {
            // If SMS couldn't send, The Application shouldn't stop working 
        }

        response.Data = _mapper.Map<CreateFeatureResponseDto>(feature);
        return response;
    }
}
