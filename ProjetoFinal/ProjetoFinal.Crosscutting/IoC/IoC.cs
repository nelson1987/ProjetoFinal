using Ephesto.Dal.Contexts;
using Ephesto.Domain.Interfaces.Repository;
using Ephesto.Domain.Interfaces.Service;
using Ephesto.Domain.Interfaces.UnitOfWork;
using Ephesto.Repository.Repositories;
using Ephesto.Repository.UnitOfWorks;
using Ephesto.Service.Services;
using SimpleInjector;
using System.Data.Entity;

namespace Ephesto.Crosscutting.IoC
{
    public static class IoC
    {
        public static Container Bootstraper(Container container)
        {
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Singleton);
            container.Register<IPerfilRepository, PerfilRepository>();
            container.Register<IUsuarioService, UsuarioService>();
            container.Register<DbContext, ProjetoFinalContext>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Singleton);

            container.Verify();
            return container;
        }
    }
}
