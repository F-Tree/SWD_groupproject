﻿using Application.Interface;
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
    public class GroupRepository : GenericRepository<GroupChatEntity>, IGroupRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;

        public GroupRepository(AppDbContext dbContext, ICurrentTime timeService, IClaimService claimsService) : base(dbContext, timeService, claimsService)
        {
            _appDbContext = dbContext;
            _currentTime = timeService;
            _claimService = claimsService;
        }
        public async Task<bool> CheckGroupName(string groupName)
        {
            return await _appDbContext.GroupChat.AnyAsync(u => u.GroupName == groupName);
        }
    }
}
