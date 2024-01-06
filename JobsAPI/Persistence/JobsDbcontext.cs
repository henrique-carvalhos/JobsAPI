using JobsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobsAPI.Persistence
{
    public class JobsDbcontext : DbContext
    {
        public JobsDbcontext(DbContextOptions<JobsDbcontext> options) : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.Entity<Job>(o =>
            {
                o.HasKey(j => j.Id);
            });
        }
    }
}
