namespace Pet_Doc_BE_Domain.Specifications;

using System.Linq.Expressions;

public abstract class Specification<T>
{
    public virtual bool IsSatisfied(T value)
    {
        var callBack = ToExpression().Compile();

        return callBack(value);
    }

    public Specification<T> And(Specification<T> spec) 
        => new BinarySpec(this, spec, true);
    public Specification<T> Or(Specification<T> spec) 
        => new BinarySpec(this, spec, false);

    public abstract Expression<Func<T, bool>> ToExpression();

   public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
     => specification.ToExpression();


    private sealed class BinarySpec : Specification<T>
    {
        private Specification<T> _left;
        private Specification<T> _right;
        private bool _andOpertator;

        internal BinarySpec(Specification<T> left, Specification<T> right, bool andOperator)
        {
            _left = left;
            _right = right;
            _andOpertator = andOperator;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            Expression<Func<T, bool>> leftExpression = _left;
            Expression<Func<T, bool>> rightExpression = _right;

            BinaryExpression andExpression = _andOpertator 
                ? Expression.AndAlso(leftExpression.Body, rightExpression.Body) 
                : Expression.OrElse(leftExpression.Body, rightExpression.Body);
            
            var parameter = Expression.Parameter(typeof(T));
            andExpression = (BinaryExpression)new ParameterReplacer(parameter).Visit(andExpression);
            andExpression = andExpression ?? throw new InvalidOperationException("Binary expression cannot be null.");

            return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
        }
    }

    private class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression parameter;

        protected override Expression VisitParameter(ParameterExpression node)
            => base.VisitParameter(this.parameter);

        internal ParameterReplacer(ParameterExpression parameter)
            => this.parameter = parameter;
    }
}


