using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RegisterUserAPI.Models;

namespace WebApp.Data
{
    public class MyProjContext : DbContext
    {
        public MyProjContext (DbContextOptions<MyProjContext> options)
            : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; } = default!;
    }
}
