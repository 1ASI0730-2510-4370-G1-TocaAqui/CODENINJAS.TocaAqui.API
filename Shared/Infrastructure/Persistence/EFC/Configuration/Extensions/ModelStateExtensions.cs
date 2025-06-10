using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace tocaaqui_backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     Extensions for Entity Framework model configuration
/// </summary>
public static class ModelStateExtensions
{
    /// <summary>
    ///     Extension method to use snake_case naming convention for database objects
    /// </summary>
    /// <param name="builder">The ModelBuilder instance</param>
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Convert table names to snake_case
            entity.SetTableName(entity.GetTableName()?.Underscore());

            // Convert column names to snake_case
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().Underscore());
            }

            // Convert foreign key names to snake_case
            foreach (var key in entity.GetKeys())
            {
                key.SetName(key.GetName()?.Underscore());
            }

            // Convert foreign key constraint names to snake_case
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()?.Underscore());
            }

            // Convert index names to snake_case
            foreach (var index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName()?.Underscore());
            }
        }
    }
} 
