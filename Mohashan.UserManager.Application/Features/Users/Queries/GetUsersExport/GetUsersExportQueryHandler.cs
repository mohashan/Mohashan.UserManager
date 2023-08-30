using AutoMapper;
using MediatR;
using Mohashan.UserManager.Application.Contracts.Infrastructure;
using Mohashan.UserManager.Application.Contracts.Persistence;

namespace Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;

public class GetUsersExportQueryHandler : IRequestHandler<GetUsersExportQuery, UserExportFileVm>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ICsvExporter _csvExporter;

    public GetUsersExportQueryHandler(IMapper mapper, IUserRepository userRepository, ICsvExporter csvExporter)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _csvExporter = csvExporter;
    }

    public async Task<UserExportFileVm> Handle(GetUsersExportQuery request, CancellationToken cancellationToken)
    {
        var allUsers = _mapper.Map<List<UserExportDto>>(await _userRepository.GetUserListWithTypeAsync()).OrderBy(c => c.Name).ToList();

        var fileData = _csvExporter.ExportUsersToCsv(allUsers);

        var userExportFileDto = new UserExportFileVm()
        {
            ContentType = "text/csv",
            Data = fileData,
            UserExportFileName = $"{Guid.NewGuid()}.csv"
        };

        return userExportFileDto;
    }
}