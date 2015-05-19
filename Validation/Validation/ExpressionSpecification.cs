using System;

namespace Validation
{
    /// <summary>
    /// ExpressionSpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        #region Fields

        private readonly Func<T, Boolean> expression;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        public ExpressionSpecification(Func<T, Boolean> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            this.expression = expression;
        }

        #endregion

        #region CompositeSpecification Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool IsSatisfiedBy(T o)
        {
            return expression(o);
        }

        #endregion
    }
}
