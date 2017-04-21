using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationInterface;
using Domain.Model;
using Infrastructure.UnitOfWork;
using Model.Repository.Role;

namespace Re
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        public RoleService(IUnitOfWork unitOfWOrk, IRoleRepository roleRepository)
        {
            _unitOfWork = unitOfWOrk;
            _roleRepository = roleRepository;
        }
        public void Add(Role permissions)
        {
            _roleRepository.Add(permissions);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public IList<Role> Fetch()
        {
            return _roleRepository.All().Select(_ => new Role
            {
                Id = _.Id,
                Name = _.Name,
                No = _.No
            })?.ToList();
        }
    }
}
