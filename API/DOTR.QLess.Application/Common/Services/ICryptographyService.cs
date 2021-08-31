using System;
using System.Collections.Generic;
using System.Text;

namespace DOTR.QLess.Application.Common.Services
{
    public interface ICryptographyService
    {
        string GenerateRandomPassword();
        string HashPassword(string password, string salt);
        string GenerateHashedPasswordWithSalt(string password, ref string salt);
        string GenerateRefreshToken();
    }
}
