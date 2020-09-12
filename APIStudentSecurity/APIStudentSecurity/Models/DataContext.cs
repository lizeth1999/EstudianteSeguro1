using System.Data.Entity;

namespace APIStudentSecurity.Models
{
    public class DataContext: DbContext 
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<APIStudentSecurity.Models.Students> Students { get; set; }
    }
}