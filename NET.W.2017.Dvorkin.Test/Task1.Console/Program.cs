using System.Collections.Generic;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repository=new SqlRepository();
            PasswordCheckerService service= new PasswordCheckerService(repository);
            List<ICheck> check = new List<ICheck>();
            check.Add(new DefaultCheck());
            //string password = "1234567QWER";
            string password = string.Empty;
            service.VerifyPassword(password, check);
            System.Console.WriteLine(service.VerifyPassword(password, check));
        }
    }
}
