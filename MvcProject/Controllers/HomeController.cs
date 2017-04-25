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
        public HomeController(IPermissionsService permissionService,IRoleService roleService)
        {
            _permissionService = permissionService;
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.ParentPermissions = _permissionService.ParentPermissions();
            ViewBag.PermissionsMenu = _permissionService.GetMenu(_permissionService.Fetch(),0);
            ViewBag.RoleMenu = _roleService.GetMenu();
            return View();
        }

        public ActionResult AddPermissions(PermissionsAddModel permissions)
        {
            _permissionService.Add(new Permissions { IsParent = permissions.IsParent == 1, Name = permissions.Name, ParentId = permissions.ParentId });
            return RedirectToAction("Index","Home");
        }

        public ActionResult AddRoles(RoleAddModel model)
        {
            _roleService.AddRoleAndMap(model);
            return RedirectToAction("Index", "Home");
        }


    }
}
