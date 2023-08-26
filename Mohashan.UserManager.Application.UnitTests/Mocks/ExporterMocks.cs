using Mohashan.UserManager.Application.Contracts.Infrastructure;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;
using Moq;
using System.Text;

namespace Mohashan.UserManager.Application.UnitTests.Mocks;

public static class ExporterMocks
{
    public static Mock<ICsvExporter> GetCsvExporter()
    {
        var mockCsvExporter = new Mock<ICsvExporter>();
        mockCsvExporter.Setup(exp => exp.ExportUsersToCsv(It.IsAny<List<UserExportDto>>())).Returns((List<UserExportDto> users) =>
        {
            return Encoding.UTF8.GetBytes(users.Count.ToString());
        });

        return mockCsvExporter;
    }
}