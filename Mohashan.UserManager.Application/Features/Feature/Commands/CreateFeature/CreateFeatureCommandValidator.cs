using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Feature.Commands.CreateFeature;

public class CreateFeatureCommandValidator:AbstractValidator<CreateFeatureCommand>
{
    public CreateFeatureCommandValidator():base()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} length must be less than 100");

    }
}
