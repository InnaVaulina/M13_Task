using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
//using M13__approach;

namespace М13_Task1
{

    public interface IClient
    {
        string Name();
 

    }

    /// <summary>
    /// клиент
    /// </summary>
    public class Client
    {
        int clientId;
        //public List<IAccount> accounts;
        public List<IAccount> Accounts { get; set; }
        /// <summary>
        /// создан клиент
        /// </summary>
        public Client(int idForm)
        {
            clientId = idForm;
            //accounts = new List<IAccount>();
            Accounts = new List<IAccount>();
        }



        public int ClientId { get { return clientId; } }

  

        /// <summary>
        /// клиент открывает счет
        /// </summary>
        /// <returns></returns>
        public void AddAccount(IAccount newAccount)
        {
            this.Accounts.Add(newAccount);
        }




        public override string ToString()
        {
            return $"{this.clientId}:";
        }

    }
}
