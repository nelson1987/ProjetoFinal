using ProjetoFinal.Dal.Contexts;
using ProjetoFinal.Domain.Interfaces.Repository;
using ProjetoFinal.Domain.Interfaces.Service;
using ProjetoFinal.Domain.Interfaces.UnitOfWork;
using ProjetoFinal.Repository.Repositories;
using ProjetoFinal.Repository.UnitOfWorks;
using ProjetoFinal.Service.Services;
using SimpleInjector;
using System.Data.Entity;

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
