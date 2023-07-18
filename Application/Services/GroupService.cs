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

        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            _groupRepository = groupRepository;
            _unitOfWork = unitOfWork;
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
            await _groupRepository.AddAsync(newGroup);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
