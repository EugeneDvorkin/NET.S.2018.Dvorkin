using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Broker
    {  
        public string Name { get; set; }

        public Broker(string name, Stock stock)
        {
            this.Name = name;
            stock.Manager += Update;
        }

        public void Update(object sender,StockInfoEventArgs info)
        {
            if (info.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, info.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, info.USD);
        }

        public void StopTrade(Stock manager)
        {
            manager.Manager -= Update;
        }
    }
}
