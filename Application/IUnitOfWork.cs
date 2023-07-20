using Application.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public  interface IUnitOfWork
    {
        public IFamilyTreeRepository FamilyTreeRepository { get; }
        public IUserRepository UserRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IPersonRepository PersonRepository { get; }
        public IUserInGroupRepository UserInGroupRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
