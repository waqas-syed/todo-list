using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Lists.Persistence.Repositories
{
    /// <summary>
    /// Interface for generic repository
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Commits the changes to the database
        /// </summary>
        void Commit();
    }
}
