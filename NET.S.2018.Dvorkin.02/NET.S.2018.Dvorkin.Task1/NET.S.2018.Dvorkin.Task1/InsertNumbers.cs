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
        /// <param name="targetNumber">Inserted number</param>
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
        public static int InsertNumber(int targetNumber, int insertNumber, int startBit, int endBit)
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

            if (targetNumber<=0 || insertNumber<0)
            {
                throw new ArgumentException($"{nameof(targetNumber)} or{nameof(insertNumber)} must be greater than 0");
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
            while (targetNumber > 0)
            {
                targetNumberBiteArray[counterTargetArray] = targetNumber % 2;
                targetNumber /= 2;
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

            //targetNumber = Convert.ToInt32(temp);
            return Convert.ToInt32(temp);
            #endregion
        }

        /// <summary>
        /// Inserts bites from second number into first from required range
        /// </summary>
        /// <param name="targetNumber">The target number.</param>
        /// <param name="insertNumber">The insert number.</param>
        /// <param name="startBit">The start bit.</param>
        /// <param name="endBit">The end bit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// startBit
        /// or
        /// targetNumber
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// startBit
        /// or
        /// endBit
        /// </exception>
        public static int InsertNumber_BitsOperation(int targetNumber, int insertNumber, int startBit, int endBit)
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

            if (targetNumber <= 0 || insertNumber < 0)
            {
                throw new ArgumentException($"{nameof(targetNumber)} or{nameof(insertNumber)} must be greater than 0");
            }

            #endregion

            insertNumber &= ~-(1 << endBit - startBit);
            insertNumber <<= startBit;
            int tRightPart = targetNumber & ~-(1 << startBit);
            int tLeftPart = targetNumber & -(1 << endBit);
            targetNumber = tLeftPart | tRightPart;
            targetNumber |= insertNumber;
            return targetNumber;
        }
    }
}
