using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BankManager manager=new BankManager();
            Bank bank=new Bank("1", manager);
            Broker broker=new Broker("1", manager);
            Stock stock=new Stock(manager);
            stock.Market();
        }
    }
}
