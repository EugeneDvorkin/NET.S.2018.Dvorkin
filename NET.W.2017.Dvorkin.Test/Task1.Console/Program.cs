using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository=new SqlRepository();
            PasswordCheckerService service= new PasswordCheckerService(repository);
            //string password = "1234567QWER";
            string password = string.Empty;
            //System.Console.WriteLine(service.VerifyPassword(password));
        }
    }
}
