using System;

namespace Validation
{
    /// <summary>
    /// NotSpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotSpecification<T> : Specification<T>
    {
        #region Fields

        private readonly Specification<T> specification;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specification"></param>
        public NotSpecification(Specification<T> specification)
        {
            this.specification = specification;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public Specification<T> Specification
        {
            get { return specification; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override Boolean IsSatisfiedBy(T item)
        {
            return !specification.IsSatisfiedBy(item);
        }
    }
}
