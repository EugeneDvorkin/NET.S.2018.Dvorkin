using System;

namespace Task3
{
    public sealed class BankManager
    {
        public event EventHandler<StockInfoEventArgs> Manager = delegate { };

        public void AddManager(int usd, int euro)
        {
            OnUpdateManager(new StockInfoEventArgs(usd,euro));
        }

        private void OnUpdateManager(StockInfoEventArgs e)
        {
            EventHandler<StockInfoEventArgs> temp = Manager;
            temp?.Invoke(this, e);
        }
    }
}