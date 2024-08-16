using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Repositories;


namespace ExaminationSystem
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}
