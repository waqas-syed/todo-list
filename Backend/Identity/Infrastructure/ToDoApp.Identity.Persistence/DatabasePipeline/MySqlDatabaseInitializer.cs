using System.Data.Entity;

namespace ToDoApp.Identity.Persistence.DatabasePipeline
{
    /// <summary>
    ///  Creates database if it doesn't exist
    /// </summary>
    public class MySqlDatabaseInitializer : IDatabaseInitializer<AuthContext>
    {
        /// <summary>
        /// Initialize the database with the provided data
        /// </summary>
        /// <param name="context"></param>
        public void InitializeDatabase(AuthContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
