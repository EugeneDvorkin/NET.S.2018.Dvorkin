using System;
using System.Collections.Generic;

namespace Task3
{
    public class Stock
    {
        private StockInfoEventArgs stocksInfo;

        private BankManager manager;        

        public Stock(BankManager manager)
        {
            this.manager = manager;
        }

        public void Market()
        {
            Random rnd = new Random();
            manager.AddManager(rnd.Next(20, 40), rnd.Next(20, 40));
        }
    }
}
