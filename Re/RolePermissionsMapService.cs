using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ApplicationInterface;
using Domain.Model;
using Infrastructure.UnitOfWork;
using Model.Dtos;
using Model.Repository.RolePermissionsMap;

namespace Re
{
    public class RolePermissionsMapService:IRolePermissionsMapService
    {

        private readonly IUnitOfWork _unitOfWOrk;
        private readonly IRolePermissionsMapRepository _rolePermissionsMapRepository;
        private readonly IPermissionsService _permissionService;
        public RolePermissionsMapService(IUnitOfWork unitOfWork,IRolePermissionsMapRepository rolePermissionMapRepositoty,IPermissionsService permissionsService)
        {
            _unitOfWOrk = unitOfWork;
            _rolePermissionsMapRepository = rolePermissionMapRepositoty;
            _permissionService = permissionsService;
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

        public void DeleteByRoleId(int roleId)
        {
            foreach (var variable in this.Query(m=>m.RoleId==roleId))
            {
                _rolePermissionsMapRepository.Delete(new RolePermissionsMap { Id =variable.Id});
            }
            _unitOfWOrk.Commit();
        }

        public IList<RolePermissionsMapDto> Fetch()
        {
            return _rolePermissionsMapRepository.All().Select(_ => new RolePermissionsMapDto
            {
                Id = _.Id,
                ParentId = _.ParentId,
                PermissionId = _.PermissionId,
                RoleId = _.RoleId
            })?.ToList();
        }

        public IList<RolePermissionsMapDto> Query(Expression<Func<RolePermissionsMap, bool>> param)
        {
           return _rolePermissionsMapRepository.Fetch(param).Select(_ => new RolePermissionsMapDto
           {
               Id = _.Id,
               ParentId = _.ParentId,
               PermissionId = _.PermissionId,
               RoleId = _.RoleId
           })?.ToList();
        }

        public IList<RolePermissionsMapMenu> GetRolePermissionsMenu(Expression<Func<RolePermissionsMap, bool>> param)
        {
            var dtos = this.Query(param);
            return GetMenu(dtos, 0, _permissionService.Fetch());
        }

        public IList<RolePermissionsMapMenu> GetMenu(IList<RolePermissionsMapDto> dtos,int parentId,IList<PermissionsDto> permissions)
        {
            return dtos.Where(m => m.ParentId == parentId).Select(_ => new RolePermissionsMapMenu
            {
                  Name=permissions.FirstOrDefault(m=>m.Id==_.PermissionId)?.Name,
                  ChildMenu=GetMenu(dtos,_.PermissionId,permissions)
            })?.ToList();
        }
    }
}
