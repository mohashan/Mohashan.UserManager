using CsvHelper;
using CsvHelper.Configuration;
using Mohashan.UserManager.Application.Contracts.Infrastructure;
using Mohashan.UserManager.Application.Features.Users.Queries.GetUsersExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Infrastructure.FileExport;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportUsersToCsv(List<UserExportDto> userExportDtos)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter,new System.Globalization.CultureInfo("en"));
            csvWriter.WriteRecords(userExportDtos);

        }

        return memoryStream.ToArray();
    }
}
