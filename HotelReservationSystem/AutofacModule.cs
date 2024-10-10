using Autofac;
using HotelReservationSystem.Data;
using HotelReservationSystem.Mediators.ReservationMediators;
using HotelReservationSystem.Mediators.RoleMediators;
using HotelReservationSystem.Mediators.RoomMediators;
using HotelReservationSystem.Mediators.UserMediators;
using HotelReservationSystem.Repositories.UnitOfWork;
using HotelReservationSystem.Services.FacilityServices;
using HotelReservationSystem.Services.ReservationServices;
using HotelReservationSystem.Services.RoleFeatureServices;
using HotelReservationSystem.Services.RoleServices;
using HotelReservationSystem.Services.RoomFacilityServices;
using HotelReservationSystem.Services.RoomReservationServices;
using HotelReservationSystem.Services.RoomServices;
using HotelReservationSystem.Services.UserRoleServices;
using HotelReservationSystem.Services.UserServices;


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
            builder.RegisterAssemblyTypes(typeof(IUserService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IUserRoleService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoleService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoleFeatureService).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            
            builder.RegisterAssemblyTypes(typeof(IRoomMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IReservationMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IRoleMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(IUserMediator).Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
