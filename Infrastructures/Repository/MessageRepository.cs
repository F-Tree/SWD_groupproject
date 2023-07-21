﻿using Application.Interface;
using Application.InterfaceRepository;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Repository
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IClaimService _claimService;
        private readonly ICurrentTime _currentTime;

        public MessageRepository(AppDbContext dbContext, ICurrentTime timeService, IClaimService claimsService) : base(dbContext, timeService, claimsService)
        {
            _appDbContext = dbContext;
            _currentTime = timeService;
            _claimService = claimsService;
        }
    }
}
