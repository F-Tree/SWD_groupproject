using Application.InterfaceRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
	public class UserInGroupRepository : IUserInGroupRepository
	{
		private readonly AppDbContext _appDbContext;
		public UserInGroupRepository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}
		public  async Task<bool> CheckUserIsInGroup(Guid id)
		{
			bool isExisted = false;
			var userInGroup =await _appDbContext.UserInGroup.SingleOrDefaultAsync(x=>x.UserId==id);
			if (userInGroup != null)
			{
				isExisted = true;
			}
			return isExisted;
		}

		public async Task CreateGroup(Guid userId,Guid groupId)
		{
			bool isExisted = await CheckUserIsInGroup(userId);
			if (!isExisted)
			{
				throw new Exception("You already join this group");
			}
			UserInGroup userInGroup = new UserInGroup
			{
				UserId= userId,
				GroupId= groupId,
				JoinedDate= DateTime.Now,
				isBanned= false,
				GroupRoleId=1
			};
			_appDbContext.UserInGroup.Add(userInGroup);

		}
	}
}
