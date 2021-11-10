using System.Linq.Expressions;
using DomainValidationCore.Interfaces.Specification;

namespace TWD.HabitTracker.Domain.Validators.ValidationSpecs
{
    internal class IsNotNullValidationSpec<TEntity> : ISpecification<TEntity>
    {
        private readonly Expression<Func<TEntity, object?>> _expression;

        public IsNotNullValidationSpec(Expression<Func<TEntity, object?>> expression)
        {
            _expression = expression;
        }

        public bool IsSatisfiedBy(TEntity entity) => _expression.Compile()(entity) != null;
    }
}