using System;
using System.Threading;
using Bll.Interface.Interface;

namespace BLL.Service
{
    /// <summary>
    /// Implementation of number generator service.
    /// </summary>
    /// <seealso cref="Bll.Interface.Interface.IGenerator" />
    public class NumberService : IGenerator
    {
        private static readonly Lazy<NumberService> instance =
            new Lazy<NumberService>(() => new NumberService(), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Prevents a default instance of the <see cref="NumberService"/> class from being created.
        /// </summary>
        private NumberService()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static NumberService Instance
        {
            get => instance.Value;
        }

        /// <summary>
        /// Generates the number.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="balance"></param>
        /// <param name="point"></param>
        /// <param name="typeId"></param>
        /// <returns>
        /// Generated number.
        /// </returns>
        public int GenerateNumber(int personId, decimal balance, int point, int typeId)
        {
            int hashcode = personId.GetHashCode();
            hashcode = (hashcode * 9) + balance.GetHashCode();
            hashcode = (hashcode * 9) + point.GetHashCode();
            hashcode = (hashcode * 9) + typeId.GetHashCode();

            return hashcode;
        }
    }
}