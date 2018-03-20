using System;

namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains insert bites method 
    /// </summary>
    public static class InsertNumbers
    {
        /// <summary>
        /// Inserts bites from second number into first from required range
        /// </summary>
        /// <param name="targretNumber">Inserted number</param>
        /// <param name="insertNumber">Inserting number</param>
        /// <param name="startBit">Start range for inserting</param>
        /// <param name="endBit">End range for inserting</param>
        /// <returns>New number, which consists of bits of the current elements</returns>
        /// <exception cref="ArgumentException">startBit bigger, then endBit</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// startBit
        /// or
        /// endBit
        /// </exception>
        public static Int32 InsertNumber(Int32 targretNumber, Int32 insertNumber, int startBit, int endBit)
        {
            #region Validation

            if (startBit > endBit)
            {
                throw new ArgumentException($"{nameof(startBit)} bigger, then {nameof(endBit)}");
            }

            if (startBit > 32)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startBit)} is more then length of bite array of target number");
            }

            if (endBit > 32)
            {
                throw new ArgumentOutOfRangeException($"{nameof(endBit)} is more then length of bite array of target number");
            }

            #endregion

            #region Fields

            int[] targetNumberBiteArray = new int[32];
            int counterTargetArray = 0;
            int[] insertNumberBiteArray = new int[32];
            int counterInsertArray = 0;
            int counter = 0;
            double temp = 0;
            #endregion

            #region MainLogic
            while (targretNumber > 0)
            {
                targetNumberBiteArray[counterTargetArray] = targretNumber % 2;
                targretNumber /= 2;
                counterTargetArray++;
            }

            while (insertNumber > 0)
            {
                insertNumberBiteArray[counterInsertArray] = insertNumber % 2;
                counterInsertArray++;
                insertNumber /= 2;
            }

            for (int i = startBit; i <= endBit; i++)
            {
                targetNumberBiteArray[i] = insertNumberBiteArray[counter];
                counter++;
            }

            for (int i = 0; i < 32; i++)
            {
                if (targetNumberBiteArray[i] == 1)
                {
                    temp += Math.Pow(2, i);
                }
            }

            //targretNumber = Convert.ToInt32(temp);
            return Convert.ToInt32(temp);
            #endregion
        }
    }
}
