using System.Data.Entity;
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
        public static Container Bootstraper(Container container)
        {
            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IPerfilRepository, PerfilRepository>();
            container.Register<IUsuarioService, UsuarioService>();
            container.Register<DbContext, ProjetoFinalContext>(Lifestyle.Singleton);
            container.Register<IUnitOfWork, UnitOfWork>();

            container.Verify();
            return container;
        }
    }
}
