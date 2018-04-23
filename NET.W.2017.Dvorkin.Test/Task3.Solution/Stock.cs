using System;
using System.Collections.Generic;

namespace Task3
{
    public class Stock
    {  
        public Stock()
        {            
        }

        public void Market()
        {
            Random rnd = new Random();
            OnUpdateStock(new StockInfoEventArgs(rnd.Next(20, 40), rnd.Next(20, 40)));            
        }

        public event EventHandler<StockInfoEventArgs> Manager = delegate { };        

        private void OnUpdateStock(StockInfoEventArgs e)
        {
            EventHandler<StockInfoEventArgs> temp = Manager;
            temp?.Invoke(this, e);
        }
    }
}
