using System.Collections.Generic;
using System.Web.Mvc;
using ApplicationInterface;
using Domain.Model;
using Model.Add;

namespace MvcProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPermissionsService _permissionService;
        private readonly IRoleService _roleService;
        private readonly IRolePermissionsMapService _rolePermissionsMapService;
        public HomeController(IPermissionsService permissionService,IRoleService roleService,IRolePermissionsMapService rolePermissionsMapService)
        {
            _permissionService = permissionService;
            _roleService = roleService;
            _rolePermissionsMapService = rolePermissionsMapService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var permissions = _permissionService.Fetch();
            ViewBag.ParentPermissions =permissions;
            ViewBag.PermissionsMenu = _permissionService.GetMenu(permissions,0);
            ViewBag.RoleMenu = _roleService.GetMenu();
            return View();
        }

        public ActionResult AddPermissions(PermissionsAddModel permissions)
        {
            _permissionService.Add(new Permissions {  Name = permissions.Name, ParentId = permissions.ParentId });
            return RedirectToAction("Index","Home");
        }

        public ActionResult AddRoles(RoleAddModel model)
        {
            _roleService.AddRoleAndMap(model);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowRoles()
        {
            return View(_roleService.Fetch());
        }

        public ActionResult Delete(int id)
        {

            _rolePermissionsMapService.DeleteByRoleId(id);
            _roleService.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}
