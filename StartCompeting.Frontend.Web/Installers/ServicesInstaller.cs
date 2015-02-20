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
                Component.For<IUserService>().ImplementedBy<UserService>().LifestylePerWebRequest(),
                Component.For<IWorkoutService>().ImplementedBy<WorkoutService>().LifestylePerWebRequest(),
                Component.For<IUserRepository>().ImplementedBy<UserRepository>().LifestylePerWebRequest(),
                Component.For<IRepository<Race>>().ImplementedBy<Repository<Race>>().LifestylePerWebRequest(),
                Component.For<IRepository<RaceType>>().ImplementedBy<Repository<RaceType>>().LifestylePerWebRequest(),
                Component.For<IRepository<Workout>>().ImplementedBy<Repository<Workout>>().LifestylePerWebRequest(),
                Component.For<IRaceTypeService>().ImplementedBy<RaceTypeService>().LifestylePerWebRequest(),
                Component.For<IRaceService>().ImplementedBy<RaceService>().LifestylePerWebRequest(),
                Component.For<ILeagueTypeService>().ImplementedBy<LeagueTypeService>().LifestylePerWebRequest(),
                Component.For<ILeagueService>().ImplementedBy<LeagueService>().LifestylePerWebRequest()
                );
        }
    }
}