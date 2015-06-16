using System.Linq;
using System.Web.Mvc;
using MVC_Security.Models;

namespace MVC_Security.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Userbeheer()
        {
            var context = new ApplicationDbContext();
            var alleUsers = context.Users;
            return View(alleUsers);
        }

        public ActionResult Rolebeheer()
        {
            var context = new ApplicationDbContext();
            var alleRoles = context.Roles;
            return View(alleRoles);
        }

        public ActionResult VerwijderUser(string id)
        {
            var context = new ApplicationDbContext();
            var user = context.Users.Find(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult VerwijderUserDoorvoeren(string id)
        {
            var context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return RedirectToAction("Userbeheer");
        }

        public ActionResult UserDetail(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext(); 
            var user = context.Users.Find( id ); 
            ViewBag.usernaam = user.UserName; 
            var rolesVoorUser = user.Roles; 
            return View( rolesVoorUser );
        }

        public ActionResult VerwijderRoleForMember(string userid, string roleid)
        {
            var context = new ApplicationDbContext();
            var user = context.Users.FirstOrDefault(u => u.Id == userid);
            var role = context.Roles.FirstOrDefault(r => r.Id == roleid);
            if (user != null && role != null)
            {
                var userRole = user.Roles.SingleOrDefault(
                    ur => (ur.UserId == userid && ur.RoleId == roleid));
                user.Roles.Remove(userRole);
                context.SaveChanges();
            }
            return RedirectToAction("UserDetail", "User", new {id = userid});
        }

        public ActionResult VerwijderRole(string id)
        {
            var context = new ApplicationDbContext();
            var role = context.Roles.Find(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult VerwijderRoleDoorvoeren(string id)
        {
            var context = new ApplicationDbContext();
            var role = context.Roles.FirstOrDefault(u => u.Id == id);
            if (role != null)
            {
                context.Roles.Remove(role);
                context.SaveChanges();
            }
            return RedirectToAction("Rolebeheer");
        }
    }
}