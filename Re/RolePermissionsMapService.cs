using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationInterface;
using Domain.Model;
using Infrastructure.UnitOfWork;
using Model.Repository.RolePermissionsMap;

namespace Re
{
    public class RolePermissionsMapService:IRolePermissionsMapService
    {

        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IRolePermissionsMapRepository _rolePermissionsMapRepository;

        public RolePermissionsMapService(IUnitOfWork unitOfWork,IRolePermissionsMapRepository rolePermissionMapRepositoty)
        {
            _unitOfWOrk = unitOfWork;
            _rolePermissionsMapRepository = rolePermissionMapRepositoty;
        }
        public void Add(RolePermissionsMap permissions)
        {
            _rolePermissionsMapRepository.Add(permissions);
            _unitOfWOrk.Commit();
        }

        public void Delete(int id)
        {
            _rolePermissionsMapRepository.Delete(id);
            _unitOfWOrk.Commit();
        }

        public IList<RolePermissionsMap> Fetch()
        {
            return _rolePermissionsMapRepository.All().Select(_ => new RolePermissionsMap
            {
                Id = _.Id,
                ParentId = _.ParentId,
                PermissionId = _.PermissionId,
                RoleId = _.RoleId
            })?.ToList();
        }
    }
}
