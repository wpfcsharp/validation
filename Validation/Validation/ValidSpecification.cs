using System;

namespace Validation
{
    /// <summary>
    /// ValidSpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ValidSpecification<T> : Specification<T>
    {
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        protected String ErrorMessage { get; set; }

        #endregion

        #region Public Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public String Validate(T item)
        {
            return IsSatisfiedBy(item) ? String.Empty : BuildErrorMessage(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected abstract String BuildErrorMessage(T item);

        #endregion
    }
}
