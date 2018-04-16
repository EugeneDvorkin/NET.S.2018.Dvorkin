namespace Task6
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPredicate<in T>
    {
        bool IsMatch(T digit);
    }
}
