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
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork,IUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<bool> CreateGroupAsync(string groupName, string groupDesc)
        {
            bool group = await _groupRepository.CheckGroupName(groupName);
            if(group)
            {
                throw new Exception("Group existed!");
            }

            FamilyGroup newGroup = new FamilyGroup
            {
                GroupName = groupName,
                GroupDescription = groupDesc,
                
            };
            var user = await _userRepository.CheckAuthentcationUser();
            if (user != null)
            {
                user.RoleId = 1;
            }
            _userRepository.Update(user);
            await _groupRepository.AddAsync(newGroup);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

		public async Task<bool> DeleteGroupAsync(Guid groupId)
		{
            var group= await _groupRepository.GetByIdAsync(groupId);
            if (group!= null)
            {
                _groupRepository.SoftRemove(group);
            }
            return await _unitOfWork.SaveChangeAsync() > 0;
		}
	}
}
