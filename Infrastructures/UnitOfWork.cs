using Application;
using Application.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        public readonly IFamilyTreeRepository _familyTreeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUserInGroupRepository _userInGroupRepository;
        public UnitOfWork(AppDbContext dbContext, IUserRepository userRepository, IGroupRepository groupRepository, IPersonRepository personRepository, IUserInGroupRepository userInGroupRepository
            , IFamilyTreeRepository familyTreeRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _personRepository = personRepository;
            _userInGroupRepository = userInGroupRepository;
            _familyTreeRepository = familyTreeRepository;
        }
        public UnitOfWork(AppDbContext dbContext,IUserRepository userRepository, IFamilyTreeRepository familyTreeRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _familyTreeRepository = familyTreeRepository;
        }
        public IFamilyTreeRepository FamilyTreeRepository => _familyTreeRepository;

        public IUserRepository UserRepository => _userRepository;
        public IPersonRepository PersonRepository => _personRepository;
        public IGroupRepository GroupRepository => _groupRepository;


        public IUserInGroupRepository UserInGroupRepository => _userInGroupRepository;

		public Task<int> SaveChangeAsync()
        {
           return _dbContext.SaveChangesAsync();
        }
    }
}
