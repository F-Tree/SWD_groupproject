﻿using Application.Interface;
using System.Security.Claims;

namespace WebApi.Services
{
    public class ClaimService : IClaimService
    {
        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var Id = httpContextAccessor.HttpContext?.User?.FindFirstValue("userId");
            GetCurrentUserId = string.IsNullOrEmpty(Id) ? Guid.Empty : Guid.Parse(Id);
        }
        public Guid GetCurrentUserId { get; }
    }
}
