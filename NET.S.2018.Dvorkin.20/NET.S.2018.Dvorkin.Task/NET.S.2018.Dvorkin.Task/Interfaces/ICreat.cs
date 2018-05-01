using NET.S._2018.Dvorkin.Task.Model;

namespace NET.S._2018.Dvorkin.Task
{
    /// <summary>
    /// Contains method for creating collection of adresses
    /// </summary>
    public interface ICreat
    {
        Adresses ReadUri(IRead read, string path, ILog logger);
    }
}