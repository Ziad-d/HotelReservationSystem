using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Repositories.UnitOfWork;
using HotelReservationSystem.Services.Rooms;


namespace ExaminationSystem
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
