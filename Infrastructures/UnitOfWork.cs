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
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IFamilyTreeRepository _familyTreeRepository;
        public UnitOfWork(AppDbContext dbContext,IUserRepository userRepository, IFamilyTreeRepository familyTreeRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _familyTreeRepository = familyTreeRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IGroupRepository GroupRepository => _groupRepository;
        public IFamilyTreeRepository FamilyTreeRepository => _familyTreeRepository;

        public Task<int> SaveChangeAsync()
        {
           return _dbContext.SaveChangesAsync();
        }
    }
}
