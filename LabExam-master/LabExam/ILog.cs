namespace Solution
{
    //выделен интерфейс для поддержания принципа открытости/закрытости. В любой момент логгер может поменяться.
    public interface ILog
    {
        void Log(string s);
    }
}