using NET.S._2018.Dvorkin.Task.Model;
using NET.S._2018.Dvorkin.Task.Tests.DI;
using Ninject;

namespace NET.S._2018.Dvorkin.Task.Tests
{
    class Program
    {
        private static readonly string pathTXT = "URL_Adress.txt";
        private static readonly string pathXML = "URL_Adress.xml";
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new Kernel());
            IRead read = kernel.Get<Read>();
            ILog logger = kernel.Get<Logger>();
            ICreat uriCreat = kernel.Get<UriCreat>();
            Adresses adresses = uriCreat.ReadUri(read, pathTXT, logger);

            XmlCreat creat = new XmlCreat(adresses, pathXML);
            creat.WriteXML();
        }
    }
}
