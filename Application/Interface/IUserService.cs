using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Security.Claims;
using Application.ViewModel;
using Application.ViewModel.UserViewModel;

namespace Application.Interface
{
    public  interface IUserService
    {
        Task<bool> RegisterAsync(string username,string password);
        Task<Token> LoginAsync(string username,string password);
        public Task<bool> UpdateUserInformation(UpdateDTO updateUser);
        Task<bool> ChangePassword(string oldPassword,string newPassword);
        Task<Token> RefreshToken(string accessToken, string refreshToken);

	}
}
