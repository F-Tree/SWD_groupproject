using Application.Interface;
using Application.InterfaceRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class UserInGroupService : IUserInGroupService
	{
		private readonly IUserInGroupRepository _userInGroupRepository;
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentTime _timeService;

		public UserInGroupService(IUserInGroupRepository userInGroupRepository,IUnitOfWork unitOfWork, ICurrentTime timeService)
		{
			_userInGroupRepository= userInGroupRepository;
			_unitOfWork= unitOfWork;
            _timeService = timeService;
		}

        public async Task<UserInGroup> AddUserToGroup(Guid userId, Guid groupId)
        {
            var group = await _unitOfWork.GroupRepository.GetByIdAsync(groupId);
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

            var newGroupDetail = new UserInGroup { UserId = user.Id, GroupId = group.Id, GroupRoleId = 2, JoinedDate = _timeService.GetCurrentTime(),  isBanned = false};
            
            await _unitOfWork.UserInGroupRepository.AddAsync(newGroupDetail);
            await _unitOfWork.SaveChangeAsync();
            return newGroupDetail;
        }
    }
}
