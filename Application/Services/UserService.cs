using Application.Common;
using Application.Interface;
using Application.InterfaceRepository;
using Application.Util;
using Application.ViewModel;
using Application.ViewModel.UserViewModel;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly ICurrentTime _currentTime;
        private readonly IMapper _mapper;
        private readonly IClaimService _claimService;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ICurrentTime currentTime, IConfiguration configuration, IMapper mapper, IClaimService claimService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _currentTime = currentTime;
            _configuration = configuration;
            _mapper = mapper;
            _claimService = claimService;
        }

		public async Task<bool> ChangePassword(string oldPassword, string newPassword)
		{
            var user = await _userRepository.CheckAuthentcationUser();
            if(user == null)
            {
                throw new Exception("You need to login to do this action");
            }
            if (!oldPassword.CheckPassword(user.Password))
            {
                throw new Exception("Password is incorrect");
            }
            var result= await _userRepository.ChangeUserPasswordAsync( user, newPassword);
            return result;
		}

		public async Task<List<User>> GetAllUser()
        {
            List<User> users = new List<User>();    
            users= await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<Token> LoginAsync(string username, string password)
        {
            bool checkEmail =await _userRepository.CheckEmail(username);
            User user = await _userRepository.FindUserByEmail(username);
            if(!checkEmail)
            {
                throw new Exception("Email not existed");
            }
            if (password.CheckPassword(user.Password)==false)
            {
                throw new Exception("Password incorrect");
            }
            var refreshToken = RefreshTokenString.GetRefreshToken();
            var accessToken = user.GenerateJsonWebToken(_configuration.GetSection("AppSetting:Token").Value!, _currentTime.GetCurrentTime());
            var expireRefreshTokenTime = DateTime.Now.AddHours(24);
            user.RefreshToken = refreshToken;
            user.AccessToken = accessToken;
            user.ExpireTokenTime=expireRefreshTokenTime;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangeAsync();
            return   new Token
            {
                emai = user.Email,
                accessToken = accessToken,
                refreshToken = refreshToken,
            };
            
        }
		public async Task<Token> RefreshToken(string accessToken, string refreshToken)
		{
			if (accessToken.IsNullOrEmpty() || refreshToken.IsNullOrEmpty())
			{
				return null;
			}
			var principal = accessToken.GetPrincipalFromExpiredToken(_configuration.GetSection("AppSetting:Token").Value!);

			var id = principal?.FindFirstValue("userID");
			_ = Guid.TryParse(id, out Guid userID);
			var userLogin = await _unitOfWork.UserRepository.GetByIdAsync(userID, x => x.Role);
			if (userLogin == null || userLogin.RefreshToken != refreshToken || userLogin.ExpireTokenTime <= DateTime.Now)
			{
				return null;
			}

			var newAccessToken = userLogin.GenerateJsonWebToken(_configuration.GetSection("AppSetting:Token").Value!, _currentTime.GetCurrentTime());
			var newRefreshToken = RefreshTokenString.GetRefreshToken();

			userLogin.RefreshToken = newRefreshToken;
			userLogin.ExpireTokenTime = DateTime.Now.AddDays(1);
			_unitOfWork.UserRepository.Update(userLogin);
			await _unitOfWork.SaveChangeAsync();

			return new Token
			{
				emai = userLogin.Email,
				accessToken = newAccessToken,
				refreshToken = newRefreshToken
			};
		}
        
		public async Task<bool> RegisterAsync(string username, string password)
        {
            bool user = await _userRepository.CheckEmail(username);
            if (user)
            {
                throw new Exception("Account already existed");
            }
            User newUser = new User
            {
                Email = username,
                Password = password.Hash(),
                RoleId=2
            };
            await _userRepository.AddAsync(newUser);
            return await _unitOfWork.SaveChangeAsync() > 0;

        }

        public async Task<bool> UpdateUserInformation(UpdateDTO updateUser)
        {
            if (updateUser != null)
            {              
                User user = (await _unitOfWork.UserRepository.GetByIdAsync(_claimService.GetCurrentUserId))!;
                _ = _mapper.Map(updateUser, user, typeof(UpdateDTO), typeof(User));

                _unitOfWork.UserRepository.Update(user);
                if (await _unitOfWork.SaveChangeAsync() > 0) return true;
                else return false;
            }
            throw new Exception("User can not be null");
        }
    }
}

