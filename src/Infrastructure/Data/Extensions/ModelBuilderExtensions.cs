using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Extensions;
/**
 * This is a C# extension method for EF Core's ModelBuilder, 
 * which allows you to apply a global query filter to all entities that implement a specific interface * 
 */

public static class ModelBuilderExtensions
{
    // Generic extension method to apply global query filters
    // TInterface: the interface that target entities must implement
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder,
        Expression<Func<TInterface, bool>> expression)
    {
        // Find all entity types in the model that implement TInterface
        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(e => e.ClrType.GetInterface(typeof(TInterface).Name) != null)
            .Select(e => e.ClrType);
        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newBody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newBody, newParam));
        }
    }
}
