using System.Data.Entity;

namespace ToDoApp.Identity.Persistence.DatabasePipeline
{
    /// <summary>
    ///  Creates database if it doesn't exist
    /// </summary>
    public class MySqlDatabaseInitializer : IDatabaseInitializer<AuthContext>
    {
        public void InitializeDatabase(AuthContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
