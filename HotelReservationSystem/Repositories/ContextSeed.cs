using HotelReservationSystem.Enums;
using HotelReservationSystem.Models;
using HotelReservationSystem.Repositories.UnitOfWork;
using System.Security.Cryptography;
using System.Text;

namespace HotelReservationSystem.Repositories
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            var adminFirstName = configuration["SeedData:AdminFirstName"];
            var adminLastName = configuration["SeedData:AdminLastName"];
            var adminEmail = configuration["SeedData:AdminEmail"];
            var adminUserName = configuration["SeedData:AdminUserName"];
            var adminPhoneNumber = configuration["SeedData:AdminPhoneNumber"];
            var adminPassword = configuration["SeedData:AdminPassword"];

            var role = "Admin";

            var roleExist = await unitOfWork.GetRepo<Role>().AnyAsync(r => r.Name == role);
            if (!roleExist)
            {
                await unitOfWork.GetRepo<Role>().AddAsync(new Role { Name = role });
                await unitOfWork.GetRepo<Role>().SaveChangesAsync();
            }

            var userRepository = unitOfWork.GetRepo<User>();

            var existingUser = await userRepository.AnyAsync(u => true);
            if (!existingUser)
            {
                var adminUser = new User
                {
                    FirstName = adminFirstName,
                    LastName = adminLastName,
                    EmailAddress = adminEmail,
                    UserName = adminUserName,
                    PhoneNumber = adminPassword,
                    Password = HashPassword(adminPassword),
                    CreateDate = DateTime.Now,
                };
                await userRepository.AddAsync(adminUser);
                await userRepository.SaveChangesAsync();

                var adminRole = (unitOfWork.GetRepo<Role>().Get(r => r.Name == role)).FirstOrDefault();
                if (adminRole != null)
                {
                    foreach (var feature in Enum.GetValues(typeof(Feature)))
                    {
                        var roleFeatureExists = unitOfWork.GetRepo<RoleFeature>().Get(rf => rf.RoleID == adminRole.ID && rf.Feature == (Feature)feature);

                        if (!roleFeatureExists.Any())
                        {
                            var roleFeature = new RoleFeature
                            {
                                RoleID = adminRole.ID,
                                Feature = (Feature)feature
                            };

                            await unitOfWork.GetRepo<RoleFeature>().AddAsync(roleFeature);
                        }
                    }
                    await unitOfWork.GetRepo<RoleFeature>().SaveChangesAsync();

                    var userRole = new UserRole
                    {
                        UserId = adminUser.ID,
                        RoleId = adminRole.ID
                    };
                    await unitOfWork.GetRepo<UserRole>().AddAsync(userRole);
                    await unitOfWork.GetRepo<UserRole>().SaveChangesAsync();
                }
            }
        }

        public static string HashPassword(string password)
        {
            var sha256 = SHA256.Create();

            var bytes = Encoding.UTF8.GetBytes(password);

            var hashBytes = sha256.ComputeHash(bytes);

            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
