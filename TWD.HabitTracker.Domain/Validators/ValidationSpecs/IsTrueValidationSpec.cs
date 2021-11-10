using System.Linq.Expressions;
using DomainValidationCore.Interfaces.Specification;

namespace TWD.HabitTracker.Domain.Validators.ValidationSpecs;

public class IsTrueValidationSpec<TEntity> : ISpecification<TEntity>
{
    private readonly Expression<Func<TEntity, bool?>> _expression;

    public IsTrueValidationSpec(Expression<Func<TEntity, bool?>> expression)
    {
        _expression = expression;
    }

    public bool IsSatisfiedBy(TEntity entity) => _expression.Compile()(entity) == true;
}