using Imtahan_Sim_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Imtahan_Sim_2.DAL
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
    }
}
