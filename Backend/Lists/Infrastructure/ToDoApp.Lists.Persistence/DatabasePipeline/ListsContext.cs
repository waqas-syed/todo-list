using System.Data.Common;
using System.Data.Entity;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;

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
        /// <param name="connection"></param>
        /// <param name="ownConnection"></param>
        public ListsContext(DbConnection connection, bool ownConnection) : base(connection, ownConnection)
        {
            
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
