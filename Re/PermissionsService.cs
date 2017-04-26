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

        public IList<PermissionsDto> Fetch()
        {
            return _permissionsRepository.All()?.Select(_ => new PermissionsDto
            {
                Id = _.Id,
                Name = _.Name,
                ParentId = _.ParentId
            })?.ToList();
        }


        public IList<PermissionsDto> Query(Expression<Func<Permissions, bool>> param)
        {
            return _permissionsRepository.Fetch(param)?.Select(_=>new PermissionsDto
            {
                Id = _.Id,
                Name = _.Name,
                ParentId = _.ParentId
            })?.ToList();
        }

        public IList<PermissionsMenu> GetMenu(IList<PermissionsDto> permissionsDto, int parentId)
        {
           return permissionsDto.Where(m => m.ParentId == parentId).Select(permission => new PermissionsMenu()
            {
                ParentId = parentId,
                Name = permission.Name,
                Id = permission.Id,
                ChildMenu = GetMenu(permissionsDto, permission.Id)
            })?.ToList();
        }
    }
}
