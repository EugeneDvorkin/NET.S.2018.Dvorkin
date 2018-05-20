using System;
using Bll.Interface.Entities;
using Bll.Interface.Interface;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static IKernel kernel;

        static void Main(string[] args)
        {
            kernel = new StandardKernel();
            kernel.ConfigurateResolver();
            IBankService service = kernel.Get<IBankService>();
            //service.NewOwner("Owner1", "Owner1", "123456", "qwer@mail.ru");
            //service.NewAccount(1, 1000m, 2);
            AccountBll account = service.FindAccount(1158234195);
            PersonBll person = service.FindPerson("123456");
            Console.WriteLine(person.Name);
            Console.WriteLine(account.PersoneId);
        }
    }
}
