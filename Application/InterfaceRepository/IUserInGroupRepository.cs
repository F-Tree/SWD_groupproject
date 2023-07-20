using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceRepository
{
	public  interface IUserInGroupRepository
	{
		Task<bool> CheckUserIsInGroup(Guid id);
		Task CreateGroup(Guid userId,Guid groupId);
	}
}
