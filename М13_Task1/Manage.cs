using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace М13_Task1
{
    public interface ITransfer<in T1>
    {
        bool TransferContr(T1 get, T1 put, float amount);
    }

    public class Manage: ITransfer<Account>
    {

        public List<Client> Clients { get; set; }           //клиенты
        public Dictionary<string, Account> accounts;        // счета

        public Client manageClient;                         // касса 
        public Account cash;


        public Manage()
        {

            Clients = new List<Client>();
            accounts = new Dictionary<string, Account>();
            manageClient = null;
            cash = null;

        }


        /// <summary>
        /// создать кассу (касса это счет типа Account, принадлежащий банку)
        /// </summary>
        /// <param name="cForm">номер клиента</param>
        /// <param name="aForm">номер счета</param>
        public void MakeCash(int cForm, string aForm)
        {
            this.manageClient = new Client(cForm);
            this.NewAccount(ref this.manageClient, aForm);
            this.cash = this.manageClient.Accounts[0] as Account;

        }


        /// <summary>
        /// добавить клиента физ.лицо
        /// </summary>
        public void NewPersonClient(
            string familyName,
            string firstName,
            string patronymicName,
            int idForm)
        {
            Person person = new Person(familyName, firstName, patronymicName, idForm);
            Clients.Add(person);
        }

        /// <summary>
        /// добавить клиента предпринимателя
        /// </summary>
        public void NewBusinessmanClient(
            string familyName,
            string firstName,
            string patronymicName,
            string inn,
            int idForm)
        {
            Businessman businessman = new Businessman(
                familyName, firstName, patronymicName, inn,
                idForm);
            Clients.Add(businessman);
        }

        /// <summary>
        /// добавить клиента организацию
        /// </summary>
        public void NewOrganisationClient(
            string name,
            string inn,
            string representative,
            int idForm)
        {
            Organization organization = new Organization(name, inn, representative, idForm);
            Clients.Add(organization);
        }


        /// <summary>
        /// новый счет типа Account
        /// </summary>
        public void NewAccount(ref Client client, string aForm)
        {
            Account myaccount = new Account(aForm);
            client.Accounts.Add(myaccount as IAccount);
            myaccount.Client = client as IClient;
            accounts.Add(aForm, myaccount);
        }


        /// <summary>
        /// новый счет типа DepositAccount
        /// </summary>
        public void NewDepoditAccount(ref Client client, string aForm)
        {
            DepositAccount myaccount = new DepositAccount(aForm);
            client.Accounts.Add(myaccount as IAccount);
            myaccount.Client = client as IClient;
            accounts.Add(aForm, myaccount);
        }

        /// <summary>
        /// закрыть счет
        /// </summary>
        public void CloseAccount(ref Client client, string aForm)
        {
            foreach (Account account in client.Accounts)
                if (account.AccountNumber.CompareTo(aForm)==0) account.CloseAccount();

        }

        /// <summary>
        /// перевод между счетами с использованием ковариантного интерфейса для определения типа счета
        /// </summary>
        /// <param name="get">счет источник</param>
        /// <param name="put">счет приемник</param>
        /// <param name="amount">сумма</param>
        /// <returns>true в случае успешности перевода</returns>
        public bool TransferCov(VariantCov<Account> get, VariantCov<Account> put, float amount)
        {

            if (get.Account.GetMoney(put.Account.Client, amount))
            {
                if (put.Account.PutMoney(get.Account.Client, amount)) return true;
                else get.Account.PutMoney(put.Account.Client, amount);

            }
            return false;

        }

        /// <summary>
        /// перевод между счетами с использованием контрвариантного интерфейса для определения типа счета
        /// </summary>
        /// <param name="get">счет источник</param>
        /// <param name="put">счет приемник</param>
        /// <param name="amount">сумма</param>
        /// <returns>true в случае успешности перевода</returns>
        public bool TransferContr(Account get, Account put, float amount)
        {
           
            if (get.GetMoney(put.Client, amount))
            {
                if (put.PutMoney(get.Client, amount)) return true;
                else get.PutMoney(put.Client, amount);

            }
            return false;
        }


    }
}
