using System;

namespace Validation
{
    /// <summary>
    /// Specification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Specification<T>
    {
        #region Public Members

        public abstract Boolean IsSatisfiedBy(T item);

        #endregion

        #region Static Members

        public static Specification<T> operator !(Specification<T> specification)
        {
            return new NotSpecification<T>(specification);
        }

        public static Specification<T> operator |(Specification<T> left, Specification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        public static Specification<T> operator &(Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static implicit operator Predicate<T>(Specification<T> specification)
        {
            return specification.IsSatisfiedBy;
        }

        #endregion
    }
}
