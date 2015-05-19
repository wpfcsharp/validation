using System;
using System.Linq;

namespace Validation
{
    /// <summary>
    /// OrSpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the OrSpecification class.
        /// </summary>
        public OrSpecification() { }

        /// <summary>
        /// Initializes a new instance of the OrSpecification class.
        /// </summary>
        /// <param name="specifications"></param>
        public OrSpecification(params Specification<T>[] specifications)
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
            return specifications.Any(specification => specification.IsSatisfiedBy(item));
        }

        #endregion
    }
}
