
using Microsoft.EntityFrameworkCore;
using RegisterUserAPI.Models;

namespace RegisterUserAPI.Data{
    public class MyProjContext: DbContext{
        public MyProjContext(DbContextOptions<MyProjContext> options) : base(options) 
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; } = default!;
    }
}