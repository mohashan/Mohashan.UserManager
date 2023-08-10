using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Infrastructure;
using Mohashan.UserManager.Application.Contracts.Persistence;
using Mohashan.UserManager.Application.Features.Group.Commands.CreateGroup;
using Mohashan.UserManager.Application.Features.Users.Commands.DeleteUser;
using Mohashan.UserManager.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Features.Users.Commands.CreateUser;

public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand, BaseResponse<CreateUserCommandResponse>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public async Task<BaseResponse<CreateUserCommandResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator(_userRepository);
        var validatorResult = await validator.ValidateAsync(request);
        if (!validatorResult.IsValid)
            throw new Exceptions.ValidationException(validatorResult);

        var user = await _userRepository.AddAsync(_mapper.Map<Domain.Entities.User>(request));

        var response = _mapper.Map<CreateUserCommandResponse>(user);
        return new BaseResponse<CreateUserCommandResponse>(response);
    }
}
