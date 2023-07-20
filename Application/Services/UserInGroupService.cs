using Application.Interface;
using Application.InterfaceRepository;
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
		public UserInGroupService(IUserInGroupRepository userInGroupRepository,IUnitOfWork unitOfWork)
		{
			_userInGroupRepository= userInGroupRepository;
			_unitOfWork= unitOfWork;
		}
		
	}
}
