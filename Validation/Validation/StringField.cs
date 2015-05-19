using System;

namespace Validation
{
    /// <summary>
    /// StringField class.
    /// </summary>
    public class StringField : Field<String>
    {
        #region Fields

        private String watermark;
        private Int32 maxLength;

        #endregion

        #region Properties

        /// <summary>
        /// Получает или задает содержимое, которое отображается в виде водяного знака в поле, когда оно пусто.
        /// </summary>
        public String Watermark
        {
            get { return watermark; }
            set { SetProperty(ref watermark, value); }
        }

        /// <summary>
        /// Возвращает или задает максимальное число символов, которые могут быть введены в поле.
        /// </summary>
        public Int32 MaxLength
        {
            get { return maxLength; }
            set { SetProperty(ref maxLength, value); }
        }

        #endregion
    }
}
