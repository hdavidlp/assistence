using DBAssistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBAssistance
{
    public class DBAssistenceContext: DbContext
    {
        public DBAssistenceContext(DbContextOptions<DBAssistenceContext> options)
            :base(options)
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Period> Period { get; set; }
        
        public DbSet<Group> Group{ get; set; }
        

    }
}