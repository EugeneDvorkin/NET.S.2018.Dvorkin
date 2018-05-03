using System;
using System.Collections.Generic;
using System.Linq;
using NET.S._2018.Dvorkin.Task.Tests.DI;
using NET.S._2018.Dvorkin.Task.v._2;
using NET.S._2018.Dvorkin.Task.v._2.Implementations;
using NET.S._2018.Dvorkin.Task.v._2.Interfaces;
using Ninject;

namespace NET.S._2018.Dvorkin.Task.Tests
{
    class Program
    {
        private static readonly string pathTXT = "URL_Adress.txt";
        private static readonly string pathXML = "URL_Adress.xml";
        static void Main(string[] args)
        {
            IKernel kernel= new StandardKernel(new Kernel());
            IRead read = kernel.Get<Read>();
            ICreat<Uri> creat = kernel.Get<Creat>();
            IParser<Uri> parser = kernel.Get<Parser>();
            List<Uri> uris = creat.Read(read, pathTXT).ToList();
            XmlCreate<Uri> xmlCreate = new XmlCreate<Uri>(pathXML);
            xmlCreate.WriteXml(parser, uris);
        }
    }
}
