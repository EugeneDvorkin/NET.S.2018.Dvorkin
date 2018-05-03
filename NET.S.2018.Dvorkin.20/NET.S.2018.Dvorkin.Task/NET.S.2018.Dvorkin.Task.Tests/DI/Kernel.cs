using System;
using NET.S._2018.Dvorkin.Task.v._2;
using NET.S._2018.Dvorkin.Task.v._2.Implementations;
using NET.S._2018.Dvorkin.Task.v._2.Interfaces;
using Ninject.Modules;

namespace NET.S._2018.Dvorkin.Task.Tests.DI
{
    public class Kernel: NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRead>().To<Read>();
            this.Bind<ILog>().To<Logger>();
            this.Bind<ICreat<Uri>>().To<Creat>().WithConstructorArgument("Logger");
            //this.Bind<IXmlCreate<Uri>>().To<XmlCreate<Uri>>().WithConstructorArgument("URL_Adress.xml");
        }
    }
}