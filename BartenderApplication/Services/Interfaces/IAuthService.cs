using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BartenderApplication.Models;
using BartenderApplication.Models.ViewModels;

namespace BartenderApplication.Services.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);
        User ValidateLogin(LoginViewModel login);


    }
}
