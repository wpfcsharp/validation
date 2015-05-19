using System;
using System.Linq;

namespace Validation
{
    /// <summary>
    /// AndSpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the AndSpecification class.
        /// </summary>
        public AndSpecification() { }

        /// <summary>
        /// Initializes a new instance of the AndSpecification class.
        /// </summary>
        /// <param name="specifications"></param>
        public AndSpecification(params Specification<T>[] specifications)
            : base(specifications) { }

        #endregion

        #region Specification Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override Boolean IsSatisfiedBy(T item)
        {
            return specifications.All(specification => specification.IsSatisfiedBy(item));
        }

        #endregion
    }
}
