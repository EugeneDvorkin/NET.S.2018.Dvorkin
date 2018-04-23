using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class StockInfoEventArgs : EventArgs
    {
        private int usd;
        private int euro;

        public StockInfoEventArgs(int usd, int euro)
        {
            this.usd = usd;
            this.euro = euro;
        }

        public int USD => usd;

        public int Euro => euro;
    }
}
