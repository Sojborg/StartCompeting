using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Core.Interfaces;
using Core.Models;
using Infrastruture.Repositories;
using Infrastruture.Services;

namespace StartCompeting.Frontend.Web.Installers
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IUserService>().ImplementedBy<UserService>(),
                Component.For<IWorkoutService>().ImplementedBy<WorkoutService>(),
                Component.For<IUserRepository>().ImplementedBy<UserRepository>(),
                Component.For<IRepository<Race>>().ImplementedBy<Repository<Race>>(),
                Component.For<IRepository<RaceType>>().ImplementedBy<Repository<RaceType>>(),
                Component.For<IRepository<Workout>>().ImplementedBy<Repository<Workout>>(),
                Component.For<IRaceTypeService>().ImplementedBy<RaceTypeService>(),
                Component.For<IRaceService>().ImplementedBy<RaceService>(),
                Component.For<ILeagueTypeService>().ImplementedBy<LeagueTypeService>(),
                Component.For<ILeagueService>().ImplementedBy<LeagueService>()
                );
        }
    }
}