using Mohashan.UserManager.Application.Models.Mail;

namespace Mohashan.UserManager.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email);
}