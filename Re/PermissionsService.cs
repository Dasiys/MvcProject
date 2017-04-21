using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationInterface;
using Domain.Model;
using Infrastructure.UnitOfWork;
using Model.Repository.Permissions;
using Repository;
using Repository.Permissions;

namespace Re
{
    public class PermissionsService : IPermissionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionRepository _permissionsRepository;
        public PermissionsService(IUnitOfWork unitOfWork, IPermissionRepository permissionsRepository)
        {
            _unitOfWork = unitOfWork;
            _permissionsRepository = permissionsRepository;
        }

        public void Add(Permissions permissions)
        {
            _permissionsRepository.Add(permissions);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _permissionsRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public IList<Permissions> Fetch()
        {
            return _permissionsRepository.All().Select(_ => new Permissions
            {
                Id = _.Id,
                IsParent = _.IsParent,
                Name = _.Name,
                ParentId = _.ParentId
            })?.ToList();
        }
    }
}
