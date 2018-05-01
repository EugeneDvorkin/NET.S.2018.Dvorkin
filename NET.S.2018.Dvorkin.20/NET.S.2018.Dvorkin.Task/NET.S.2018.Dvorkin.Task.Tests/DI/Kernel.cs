using Ninject.Modules;

namespace NET.S._2018.Dvorkin.Task.Tests.DI
{
    public class Kernel: NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRead>().To<Read>();
            this.Bind<ILog>().To<Logger>();
            this.Bind<ICreat>().To<UriCreat>();
        }
    }
}