using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Validation
{
    /// <summary>
    /// CompositeSpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        #region Fields

        protected readonly List<Specification<T>> specifications;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the CompositeSpecification class.
        /// </summary>
        /// <param name="specifications"></param>
        protected CompositeSpecification(params Specification<T>[] specifications)
        {
            this.specifications = new List<Specification<T>>(specifications);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Return generic read-only collection.
        /// </summary>
        public ReadOnlyCollection<Specification<T>> Specifications
        {
            get { return new ReadOnlyCollection<Specification<T>>(specifications); }
        }

        /// <summary>
        /// Adds an specification to the end of the collection.
        /// </summary>
        /// <param name="specification">The specification to be added to the end of the collection.</param>
        public void Add(Specification<T> specification)
        {
            specifications.Add(specification);
        }

        /// <summary>
        /// Removes the first occurrence of a specification from the collection.
        /// </summary>
        /// <param name="specification">The specification to remove from the collection.</param>
        public void Remove(Specification<T> specification)
        {
            specifications.Remove(specification);
        }

        #endregion
    }
}
