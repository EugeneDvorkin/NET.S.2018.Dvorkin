namespace NET.S._2018.Dvorkin.Task1.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerManager manager = new TimerManager();
            Timer timer = new Timer(manager);
            AnotherTimer anotherTimer=new AnotherTimer(manager);
            manager.AddTimer(5000, "efewsf", "wefewfew");
        }
    }
}
