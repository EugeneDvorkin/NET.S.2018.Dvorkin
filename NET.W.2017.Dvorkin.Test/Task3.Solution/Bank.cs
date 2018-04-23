using System;

namespace Task3
{
    public class Bank 
    {
        public string Name { get; set; }

        public Bank(string name, BankManager manager)  
        {
            this.Name = name;
            manager.Manager += Update;
        }

        public void Update(object info, StockInfoEventArgs e)
        {
            if (e.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, e.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, e.Euro);
        }
    }
}
