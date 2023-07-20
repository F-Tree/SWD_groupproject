using Application.Interface;
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
	public class UserInGroupRepository : GenericRepository<UserInGroup>, IUserInGroupRepository
	{
		private readonly AppDbContext _dbContext;

		public UserInGroupRepository(AppDbContext dbContext, ICurrentTime timeService, IClaimService claimService) : base(dbContext, timeService, claimService)
		{
			_dbContext = dbContext;
		}
			
		public  async Task<bool> CheckUserIsInGroup(Guid id)
		{
			bool isExisted = false;
			var userInGroup =await _dbContext.UserInGroup.SingleOrDefaultAsync(x=>x.UserId==id);
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
			_dbContext.UserInGroup.Add(userInGroup);

		}
	}
}
