using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Repositories.UnitOfWork;
using HotelReservationSystem.Services.FacilityServices;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.Services.RoomFacilityServices;
using HotelReservationSystem.Services.RoomReservationServices;
using HotelReservationSystem.Services.RoomServices;


namespace ExaminationSystem
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>().InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IFacilityService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomFacilityService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IReservationService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoomReservationService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
