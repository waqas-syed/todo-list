using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;
using ToDoApp.Lists.Persistence.PersistencePipeline;

namespace ToDoApp.Lists.Persistence.Repositories
{
    /// <summary>
    /// Repository for performing operations on Lists
    /// </summary>
    public class ListRepository : IListsRepository
    {
        private ListsContext _listsContext;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ListRepository()
        {
            _listsContext = new ListsContext(CreateDbConnection(), true);    
        }
        public void SaveorUpdate(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(string toDoItemId)
        {
            throw new NotImplementedException();
        }

        public IList<ToDoItem> GetAllToDoItems(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the DbConnection required for the AuthContext
        /// </summary>
        /// <returns></returns>
        public DbConnection CreateDbConnection()
        {
            var connection = DbProviderFactories.GetFactory("MySql.Data.MySqlClient").CreateConnection();
            if (connection == null)
            {
                throw new NullReferenceException("Could not create DB connection for Entity Framework");
            }
            connection.ConnectionString = ConfigurationManager.AppSettings.Get("DefaultConnection");
            return connection;
        }
    }
}
