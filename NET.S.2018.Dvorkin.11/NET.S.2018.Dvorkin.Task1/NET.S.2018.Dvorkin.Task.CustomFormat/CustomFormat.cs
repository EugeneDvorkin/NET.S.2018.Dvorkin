using System;
using System.Globalization;
using NET.S._2018.Dvorkin.Task1;

namespace NET.S._2018.Dvorkin.Task.CustomFormat
{
    public class CustomFormat : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is Book == false)
            {
                try
                {

                }
                catch (FormatException e)
                {
                    return HandleOtherFormats(format, arg);
                }
            }

            Book book = arg as Book;

            if (string.IsNullOrWhiteSpace(format))
            {
                return book.ToString();
            }

            switch (format.ToUpper())
            {
                case "IAT":
                    return book.ToString("IAT", CultureInfo.CurrentCulture);
                default:
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException($"{nameof(e)} is invalid");
                    }
            }
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
