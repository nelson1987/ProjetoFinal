using System.Data.Entity;
using System.Data.Entity.Infrastructure.DependencyResolution;
using ProjetoFinal.Dal.Contexts;
using SimpleInjector;
using ProjetoFinal.Domain.Interfaces.Repository;
using ProjetoFinal.Domain.Interfaces.Service;
using ProjetoFinal.Domain.Interfaces.UnitOfWork;
using ProjetoFinal.Repository.Repositories;
using ProjetoFinal.Repository.UnitOfWorks;
using ProjetoFinal.Service.Services;

namespace ProjetoFinal.Crosscutting.IoC
{
    public static class IoC
    {

        private static Container container;

        // Register your types, for instance:
        //container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Singleton);
        //container.Register<IUserContext, WinFormsUserContext>();
        //container.Register<Form1>();

        public static Container Bootstraper(Container container)
        {
            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IPerfilRepository, PerfilRepository>();
            container.Register<IUsuarioService, UsuarioService>();
            container.Register<DbContext, ProjetoFinalContext>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>();

            container.Verify();
            return container;
            //(Lifestyle.Singleton);

            // 3. Optionally verify the container's configuration.
            //container.Verify();

            // 4. Register the container as MVC3 IDependencyResolver.
            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
