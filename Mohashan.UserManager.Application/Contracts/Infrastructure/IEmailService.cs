﻿using Mohashan.UserManager.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohashan.UserManager.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmailAsync(Email email);
}
