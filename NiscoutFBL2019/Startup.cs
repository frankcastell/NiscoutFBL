using Microsoft.Owin;
using Owin;
using NiscoutFBL2019.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(NiscoutFBL2019.Startup))]
namespace NiscoutFBL2019
{

    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //Creamos roles y usuarios  
            CreateRolesAndUsers();

        }
        private void CreateRolesAndUsers()
        {
            //accedemos al modelo de la seguridad integrada
            ApplicationDbContext context = new ApplicationDbContext();
            //definimos las variables manejadoras de roles y usuarios
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var ManejadorUsuario = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //Verificamos la excistencia de los roles por defecto
            if (!ManejadorRol.RoleExists("Admin"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol
                var rol = new IdentityRole();
                rol.Name = "Admin";
                ManejadorRol.Create(rol);
                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "juanacuba1@gmail.com";
                user.Email = "juanacuba1@gmail.com";
                string PWD = "12345678";
                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Admin");
                }
            }

            //Verificamos la excistencia de los roles por defecto
            if (!ManejadorRol.RoleExists("Manager"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol

                var rol = new IdentityRole();
                rol.Name = "Manager";
                ManejadorRol.Create(rol);

                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "brayanoz105@gmail.com";
                user.Email = "brayanoz105@gmail.com";
                string PWD = "123456789";

                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Manager");
                }
            }

            //Verificamos la excistencia de los roles por defecto
            if (!ManejadorRol.RoleExists("Usuario"))
            {
                //sino existe, se crea el rol y se asigna un nuevo usuario con ese rol

                var rol = new IdentityRole();
                rol.Name = "Usuario";
                ManejadorRol.Create(rol);

                //creamos un primer usuario para ese rol
                var user = new ApplicationUser();
                user.UserName = "francast16@gmail.com";
                user.Email = "francast16@gmail.com";
                string PWD = "12345678";

                var chkUser = ManejadorUsuario.Create(user, PWD);
                //si se creo con exito
                if (chkUser.Succeeded)
                {
                    ManejadorUsuario.AddToRole(user.Id, "Usuario");
                }
            }
        }
    }
}
