namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains the definition of a finder tag.
    /// </summary>
    public interface IFinder
    {
        /// <summary>
        /// Finds the specified tag finder.
        /// </summary>
        /// <param name="tagFinder">The tag finder.</param>
        /// <returns>Founded book with current tag.</returns>
        Book Find(string tagFinder);
    }
}