using System.Runtime.InteropServices;

namespace NET.S._2018.Dvorkin.Task3
{
    /// <summary>
    /// Contains methods fore converting double to binary representations
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Doubles to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>String binary representations of the double</returns>
        public static string DoubleToString(this double number)
        {
            DoubleExtension numberStruct = new DoubleExtension
            {
                numberBit = number
            };
            string resultString = ConverterToString(numberStruct.longBits);

            return resultString;
        }

        /// <summary>
        /// Converters to string.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Convert to binary string</returns>
        private static string ConverterToString(ulong number)
        {
            char[] bits = new char[64];

            for (int i = 63; i > 0; i--)
            {
                bits[i] = (char)(number % 2 + 0x30);
                number /= 2;
            }
            bits[0] = (char)(number + 0x30);

            return new string(bits);
        }

        /// <summary>
        /// Structure for getting bytes of number
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleExtension
        {
            [FieldOffset(0)]
            internal readonly ulong longBits;

            [FieldOffset(0)]
            internal double numberBit;
        }
    }
}
