using System;

namespace Validation
{
    /// <summary>
    /// Field class.
    /// </summary>
    public abstract class Field : BindableBase
    {
        #region Fields

        private String id;
        private String header;
        private Int32 order;
        private Boolean isReadOnly;

        #endregion
        
        #region Property

        /// <summary>
        /// Возвращает или задает уникальный идентификатор поля.
        /// </summary>
        public String Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        /// <summary>
        /// Возвращает или задает заголовок поля.
        /// </summary>
        public String Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }
        
        /// <summary>
        /// Возвращает или задает порядковый номер поля.
        /// </summary>
        public Int32 Order
        {
            get { return order; }
            set { SetProperty(ref order, value); }
        }

        /// <summary>
        /// Возварщает значение, указывающее, является ли поле доступным только для чтения.
        /// </summary>
        public Boolean IsReadOnly
        {
            get { return isReadOnly; }
            set { SetProperty(ref isReadOnly, value); }
        }

        /// <summary>
        /// Возвращает значение, показывающее, прошло ли поле проверку валидации.
        /// </summary>
        public abstract Boolean IsValid { get; }
        
        #endregion
    }

    /// <summary>
    /// Field class.
    /// </summary>
    public class Field<T> : Field
    {
        #region Fields

        private T val;

        #endregion

        #region Ctor

        public Field()
        {
            Validations = new ValidationSpecification<T>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Возвращает или задает значение поля.
        /// </summary>
        public T Value
        {
            get { return val; }
            set { SetProperty(ref val, value); }
        }

        /// <summary>
        /// Возвращает значение, показывающее, прошло ли поле проверку валидации.
        /// </summary>
        public override Boolean IsValid
        {
            get { return Validations.IsSatisfiedBy(Value); }
        }

        /// <summary>
        /// Возвращает список проверок для поля.
        /// </summary>
        public ValidationSpecification<T> Validations { get; private set; }
        
        #endregion
    }
}
