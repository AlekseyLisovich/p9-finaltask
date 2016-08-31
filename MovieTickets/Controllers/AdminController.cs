using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MovieTickets.Models;
using MovieTickets.Models.Account;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieTickets.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : BaseController
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RoleList()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateRole(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await RoleManager.CreateAsync(new Role
                {
                    Name = model.Name,
                    Description = model.Description
                });
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            return View(model);
        }

        public async Task<ActionResult> EditRole(string id)
        {
            Role role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                return View(new EditRoleModel { Id = role.Id, Name = role.Name, Description = role.Description });
            }
            return RedirectToAction("RoleList");
        }
        [HttpPost]
        public async Task<ActionResult> EditRole(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                Role role = await RoleManager.FindByIdAsync(model.Id);
                if (role != null)
                {
                    role.Description = model.Description;
                    role.Name = model.Name;
                    IdentityResult result = await RoleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("RoleList");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }
                }
            }
            return View(model);
        }

        public async Task<ActionResult> DeleteRole(string id)
        {
            Role role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
            }
            return RedirectToAction("RoleList");
        }

        public ViewResult GetUsers()
        {
            var userRoleModels = new List<UserRole>();
            var users = UserManager.Users;
            foreach (var user in users)
            {
                userRoleModels.Add(new UserRole
                {
                    User = user,
                    Roles = UserManager.GetRoles(user.Id)
                });
            }

            return View(userRoleModels);
        }

        [HttpGet]
        public ActionResult EditUserRole(string id)
        {
            User user = UserManager.FindById(id);
            var userRoleModels = new UserRole
            {
                User = user,
                Roles = UserManager.GetRoles(user.Id)
            };
            return View(userRoleModels);
        }

        [HttpPost]
        public ActionResult EditUserRole(UserRole u, string id)
        {

            User user = UserManager.FindById(id);
            IList<string> roles = UserManager.GetRoles(user.Id);
            if (user != null)
            {
                UserManager.RemoveFromRoles(user.Id, roles.ToArray());
                UserManager.AddToRole(user.Id, u.Roles.First());
            }

            return RedirectToAction("GetUsers");
        }

        [HttpGet]
        public ActionResult DeleteUser()
        {
            return View();
        }

        [HttpPost]
        [ActionName("DeleteUser")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            User user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("GetUsers", "Admin");
                }
            }
            return RedirectToAction("GetUsers", "Admin");
        }
    }
}