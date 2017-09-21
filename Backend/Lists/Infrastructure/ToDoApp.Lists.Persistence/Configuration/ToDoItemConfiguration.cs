using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ToDoApp.Lists.Domain.Model.ToDoAggregate;

namespace ToDoApp.Lists.Persistence.Configuration
{
    /// <summary>
    /// Entity to database mapping configuration for ToDoItem
    /// </summary>
    public class ToDoItemConfiguration : EntityTypeConfiguration<ToDoItem>
    {
        /// <summary>
        /// Performs the configuration for ToDoItem database table during initialization
        /// </summary>
        public ToDoItemConfiguration()
        {
            ToTable("todoitem");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            HasKey(x => x.Id);
            
            Property(x => x.Description).IsRequired().HasMaxLength(600);
            Property(x => x.OwnerEmail).IsRequired().HasMaxLength(100);
        }
    }
}
