using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationInterface;
using Domain.Model;
using Infrastructure.UnitOfWork;
using Model.Add;
using Model.Dtos;
using Model.Repository.Role;

namespace Re
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        private readonly IPermissionsService _permissionsService;
        private readonly IRolePermissionsMapService _rolePermissionsMapService;
        public RoleService(IUnitOfWork unitOfWOrk, IRoleRepository roleRepository, IPermissionsService permissionsService, IRolePermissionsMapService rolePermissionsMapService)
        {
            _unitOfWork = unitOfWOrk;
            _roleRepository = roleRepository;
            _permissionsService = permissionsService;
            _rolePermissionsMapService = rolePermissionsMapService;
        }
        public int Add(Role role)
        {
            _roleRepository.Add(role);
            _unitOfWork.Commit();
            return role.Id;
        }

        public void AddRoleAndMap(RoleAddModel model)
        {
            var id = this.Add(new Role { Name = model.Name, No = model.No });
            var permissions = _permissionsService.Fetch();
            var rolePermissionsMap = new List<RolePermissionsMap>();
            model.PermissionIds.ForEach(m =>
            {
                var permission = permissions.FirstOrDefault(n => n.Id == int.Parse(m));
                rolePermissionsMap = GetRolePermissionsMap(rolePermissionsMap, model.PermissionIds, permissions, permission.ParentId);
                rolePermissionsMap.Add(new RolePermissionsMap
                {
                    PermissionId = int.Parse(m),
                    RoleId = id,
                    ParentId = permission.ParentId
                });
            });
            rolePermissionsMap.ForEach(m =>
            {
                m.RoleId = id;
                _rolePermissionsMapService.Add(m);
            });
            _unitOfWork.Commit();
        }

        public List<RolePermissionsMap> GetRolePermissionsMap(List<RolePermissionsMap> rolePermissionsMap, List<string> ids, IList<PermissionsDto> permissions, int parentId)
        {
            rolePermissionsMap = rolePermissionsMap ?? new List<RolePermissionsMap>();
            if (ids.IndexOf(parentId.ToString()) < 0 && rolePermissionsMap.All(n => n.PermissionId != parentId) && parentId != 0)
            {
                var permission = permissions.FirstOrDefault(n => n.Id == parentId);
                rolePermissionsMap.Add(new RolePermissionsMap
                {
                    PermissionId = parentId,
                    ParentId = permission.ParentId
                });
                rolePermissionsMap = GetRolePermissionsMap(rolePermissionsMap, ids, permissions, permission.ParentId);
            }
            return rolePermissionsMap;
        }

        public void Delete(int id)
        {
            _roleRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public IList<RolesDto> Fetch()
        {
            return _roleRepository.All().Select(_ => new RolesDto
            {
                Id = _.Id,
                Name = _.Name,
                No = _.No
            })?.ToList();
        }

        public IList<RoleMenu> GetMenu()
        {
            return this.Fetch().Select(_ => new RoleMenu
            {
                Id = _.Id,
                Name = _.Name,
                No = _.No,
                Menu=_rolePermissionsMapService.GetRolePermissionsMenu(t=>t.RoleId==_.Id)
            })?.ToList();
        }
    }
}
