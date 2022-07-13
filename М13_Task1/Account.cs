using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace М13_Task1
{
    public interface IVariantCov<out T>
    {
        T Account { get; }

    }

    public class VariantCov<T> : IVariantCov<T>

    {
        public T account;
        public VariantCov(T x) { account = x; }
        public T Account { get { return this.account; } }

    }


    public interface IAccount
    {
        string AccountNumber { get; }

        DateTime TimeCreate { get; }

        DateTime TimeClose { get; }

        float Balance { get; }

        bool CloseAccount();

        IClient Client { get; }

        string ToString();
    }


    /// <summary>
    /// счет клиента
    /// </summary>
    public class Account : IAccount, INotifyPropertyChanged
    {
        static int nombering;

        static Account() 
        {
            nombering = 0;
        }

        string accountNumber;
        protected string accountVariant;
        DateTime tCreate;
        DateTime tClose;
        float balance;
        IClient client;


        public Account()
        {
            accountNumber = $"0000{nombering}";
            accountNumber = accountNumber.Substring(accountNumber.Length - 5);
            nombering++;
            tCreate = DateTime.Now;
            tClose = default(DateTime);
            balance = 0;
            client = null;
        }

        public IClient Client { get { return client; } set { client = value; } }

        public string AccountNumber { get { return this.accountNumber; } }

        public DateTime TimeCreate { get { return tCreate; } }

        public DateTime TimeClose { get { return this.tClose; } }

        public float Balance { get { return balance; } }

        

        /// <summary>
        /// положить сумму на счет
        /// </summary>
        /// <param name="amount">сумма</param>
        public virtual bool PutMoney(IClient other, float amount)
        {
            if (this.tClose == default(DateTime))
            { 
                balance += amount;
                OnPropertyChanged("Balance");
                return true; 
            }
            else return false;

        }

        /// <summary>
        /// снять сумму со счета
        /// </summary>
        /// <param name="amount">сумма</param>
        public virtual bool GetMoney(IClient other, float amount)
        {
            bool x = false;
            if (this.tClose == default(DateTime))
                if (amount <= this.balance) 
                { 
                    balance -= amount;
                    OnPropertyChanged("Balance");
                    x = true; 
                }
            return x;
        }

        /// <summary>
        /// закрыть счет
        /// </summary>
        public bool CloseAccount()
        {
            if (balance == 0) 
            { 
                tClose = DateTime.Now;
                OnPropertyChanged("TimeClose");
                return true; 
            }
            else return false;
        }



        public override string ToString()
        {
            return $"Счет: {AccountNumber} ({TimeCreate}, {TimeClose}): {Balance}";
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
