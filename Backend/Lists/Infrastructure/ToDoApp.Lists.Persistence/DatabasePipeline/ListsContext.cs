using System.Data.Common;
using System.Data.Entity;
using ToDoApp.Common;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;
using ToDoApp.Lists.Persistence.Configuration;

namespace ToDoApp.Lists.Persistence.DatabasePipeline
{
    /// <summary>
    /// DbContext for the Lists Bounded Context
    /// </summary>
    public class ListsContext : DbContext
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ListsContext() : base(Constants.DatabaseConnectionString)
        {
            
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ToDoItemConfiguration());
        }
    }
}
