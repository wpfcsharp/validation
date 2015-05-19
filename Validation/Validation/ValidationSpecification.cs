using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Validation
{
    /// <summary>
    /// ValidationSpecification class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ValidationSpecification<T> : Specification<T>
    {
        #region Fields

        private readonly List<ValidSpecification<T>> validSpecifications;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the ValidationSpecification class.
        /// </summary>
        /// <param name="validSpecifications"></param>
        public ValidationSpecification(params ValidSpecification<T>[] validSpecifications)
        {
            this.validSpecifications = new List<ValidSpecification<T>>(validSpecifications);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Return generic read-only collection.
        /// </summary>
        public ReadOnlyCollection<ValidSpecification<T>> Specifications
        {
            get { return new ReadOnlyCollection<ValidSpecification<T>>(validSpecifications); }
        }

        /// <summary>
        /// Adds an specification to the end of the collection.
        /// </summary>
        /// <param name="specification">The specification to be added to the end of the collection.</param>
        public void Add(ValidSpecification<T> specification)
        {
            validSpecifications.Add(specification);
        }

        /// <summary>
        /// Removes the first occurrence of a specification from the collection.
        /// </summary>
        /// <param name="specification">The specification to remove from the collection.</param>
        public void Remove(ValidSpecification<T> specification)
        {
            validSpecifications.Remove(specification);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public String Validate(T item)
        {
            var result = String.Empty;
            foreach (var validationSpecification in validSpecifications)
            {
                result = validationSpecification.Validate(item);
                if (!String.IsNullOrEmpty(result)) break;
            }
            return result;
        }

        #endregion

        #region Specification Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override Boolean IsSatisfiedBy(T item)
        {
            return !validSpecifications.Any() || validSpecifications.All(specification => specification.IsSatisfiedBy(item));
        }

        #endregion
    }
}
