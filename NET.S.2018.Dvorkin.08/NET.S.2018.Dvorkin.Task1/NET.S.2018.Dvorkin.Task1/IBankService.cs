
namespace NET.S._2018.Dvorkin.Task1
{
    /// <summary>
    /// Contains required methods for bank account.
    /// </summary>
    /// <typeparam name="T">Type of account.</typeparam>
    interface IBankService<T>
    {
        T Replenishment(decimal account, T acc);
        T Withdrawal(decimal account, T acc);
        //T NewAcc(string number, string name, string surname, string passport, decimal account = 0, int score = 0);
        void CloseAcc(T acc);
    }
}
