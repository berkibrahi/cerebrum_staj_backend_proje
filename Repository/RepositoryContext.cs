using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
	public class RepositoryContext:DbContext
	{
        public RepositoryContext(DbContextOptions options):base(options)
        {
            
        }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		public DbSet<Comment> Comments { get; set; }
		public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }


    }
}
