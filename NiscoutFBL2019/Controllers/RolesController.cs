using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NiscoutFBL2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NiscoutFBL2019.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public RolesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Roles

       
        public ActionResult Index2()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!isAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = context.Roles.ToList();
            return View(Roles);
        }
        private bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                //Si tiene al menos un rol
                if (s.Count > 0)
                {
                    //Si su primer rol es administrador
                    if (s[0].ToString() == "Admin")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(string roleDescripcion)
        {
            try
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                if (!roleManager.RoleExists(roleDescripcion))
                {
                    var role = new IdentityRole { Name = roleDescripcion };
                    roleManager.Create(role);
                    context.SaveChanges();
                    return RedirectToAction("Index2");
                }
                else
                {
                    ModelState.AddModelError("Descripcion", "Ya existe un rol con esa descripcion.");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}