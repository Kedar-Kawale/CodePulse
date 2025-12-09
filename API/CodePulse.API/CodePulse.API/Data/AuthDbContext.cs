using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "d1611451-1643-49eb-b0e4-babb98fd6078";
            var writerRoleId = "a5ccd781-4da2-42ea-9f1b-c7e8f0498fc1";

            //Create Reader and Writer Role
            var roles = new List<IdentityRole>
            {
                new IdentityRole()    // this role is for the Reader role (normal user)
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    //ConcurrencyStamp = readerRoleId      =>this is commented to avoid dynamic value issue
                },

                new IdentityRole()  // this role is for the Writer role (Admin user)
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    //ConcurrencyStamp = writerRoleId     =>this is commented to avoid dynamic value issue
                }
            };

            //Seed the Roles
            builder.Entity<IdentityRole>().HasData(roles);

            // Create an Admin user (Default User)

            var adminUserId = "8b278087-9a31-4db3-b6f7-94823d4c3035";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@codepulse.com",
                Email = "admin@codepulse.com",
                NormalizedEmail = "admin@codepulse.com".ToUpper(),
                NormalizedUserName = "admin@codepulse.com".ToUpper(),

                //pasting the static Hash here to solve error of dynamic value
                PasswordHash = "AQAAAAIAAYagAAAAECy/q30zQKz1r7LbqTALIhqrXkwbABE+Zqi6K9tGKVAraDnJ0yj10P5mBBxNh7+wQQ==",

                // Add a static SecurityStamp to avoid dynamic value error
                SecurityStamp = "d6e87f1a-b2c3-4d5e-6f7a-8b9c0d1e2f3a",
                //Add the static ConcurrencyStamp for 'IdentityUser' to avoid dynamic value error
                ConcurrencyStamp = "34a5b6c7-d8e9-4f5a-8b01-570a2f44047a" // Use this static GUID
            };


            // admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Kedar@asp123");   =>this is commented to avoid dynamic value error

            //  seed the 'Admin' into Dababase 
            builder.Entity<IdentityUser>().HasData(admin);

            // Give Roles to Admin ( admin can read and write)

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }
            };

            //again seed the roles 
            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
