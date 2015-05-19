using System;
using System.Collections.Generic;

namespace Validation
{
    /// <summary>
    /// MinValidation class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CompareValidation<T> : ValidSpecification<T> where T : IComparable<T>
    {
        #region Ctor

        public CompareValidation(T value, ComparisonCondition condition, String errorMessage = null)
        {
            Value = value;
            Condition = condition;
            ErrorMessage = errorMessage;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public ComparisonCondition Condition { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public T Value { get; private set; }

        #endregion

        #region ValidSpecification Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override String BuildErrorMessage(T item)
        {
            return ErrorMessage ?? String.Format("значение '{0}' не соответствует условиям", Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override Boolean IsSatisfiedBy(T item)
        {
            var comparer = new GenericComparer<T>();
            var result = comparer.Compare(Value, item);
            if (result < 0)
            {
                // Значение параметра x меньше значения параметра y
                switch (Condition)
                {
                    case ComparisonCondition.Equal:
                    case ComparisonCondition.LessThan:
                    case ComparisonCondition.LessThanOrEqual:
                        return false;
                    default:
                        return true;
                }
            }
            if (result > 0)
            {
                // Значение x больше значения y
                switch (Condition)
                {
                    case ComparisonCondition.Equal:
                    case ComparisonCondition.GreaterThan:
                    case ComparisonCondition.GreaterThanOrEqual:
                        return false;
                    default:
                        return true;
                }
            }
            // Значения параметров x и y равны
            switch (Condition)
            {
                case ComparisonCondition.NotEqual:
                case ComparisonCondition.LessThan:
                case ComparisonCondition.GreaterThan:
                    return false;
                default:
                    return true;
            }
        }

        #endregion
    }

    /// <summary>
    /// ComparisonCondition enum.
    /// </summary>
    public enum ComparisonCondition
    {
        Equal,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
    }

    /// <summary>
    /// GenericComparer class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class GenericComparer<T> : Comparer<T> where T : IComparable<T>
    {

        public override int Compare(T x, T y)
        {
            if ((object)x != null)
            {
                return (object)y != null ? x.CompareTo(y) : 1;
            }
            return (object)y != null ? -1 : 0;
        }

        public override bool Equals(object obj)
        {
            return obj is GenericComparer<T>;
        }

        public override int GetHashCode()
        {
            return GetType().Name.GetHashCode();
        }
    }
}
