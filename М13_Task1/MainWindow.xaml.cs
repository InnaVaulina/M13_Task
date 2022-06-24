﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using M13__approach;

namespace М13_Task1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manage bankA = new Manage();
        Account selected1;
        Account selected2;
         


        public MainWindow()
        {
            InitializeComponent();

            
            bankA.NewPersonClient("Иванов", "Иван", "Иванович", 1);
            bankA.NewPersonClient("Савина", "Анна", "Александровна", 2);
            bankA.NewPersonClient("Кривчанская", "Наталья", "Игоревна", 3);
            Client x = bankA.Clients[0];
            bankA.NewAccount(ref x, "00001");
            bankA.NewDepoditAccount(ref x, "00004");
            x = bankA.Clients[1];
            bankA.NewAccount(ref x, "00002");
            bankA.NewDepoditAccount(ref x, "00005");
            x = bankA.Clients[2];
            bankA.NewAccount(ref x, "00003");
            bankA.NewDepoditAccount(ref x, "00006");

            bankA.NewBusinessmanClient("Петров", "Петр", "Петрович", "111", 4);
            bankA.NewBusinessmanClient("Шкарпитный", "Владимир", "Константинович", "111", 5);
            x = bankA.Clients[3];
            bankA.NewAccount(ref x, "00007");
            bankA.NewDepoditAccount(ref x, "00008");
            x = bankA.Clients[4];
            bankA.NewAccount(ref x, "00009");
            bankA.NewDepoditAccount(ref x, "00010");

            bankA.NewOrganisationClient("OOO Ромашка", "112", "Романов Роман Романович", 6);
            bankA.NewOrganisationClient("OOO Лютик", "159", "Лютый Алексей Борисович", 7);
            x = bankA.Clients[5];
            bankA.NewAccount(ref x, "00011");
            bankA.NewDepoditAccount(ref x, "00012");
            x = bankA.Clients[6];
            bankA.NewAccount(ref x, "00013");
            bankA.NewDepoditAccount(ref x, "00014");

            bankA.MakeCash(0, "00000");
            
            ClientList.ItemsSource = bankA.Clients;
            
            this.DataContext = bankA;
            Cash.DataContext = bankA.cash;
            selected1 = bankA.cash;
            selected2 = bankA.cash;
            SourceAccount.Text = bankA.cash.AccountNumber;

        }



        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            float sum = 0;
            if (float.TryParse(Amount1.Text, out sum))
                bankA.cash.PutMoney(bankA.manageClient as IClient, sum);
            else MessageBox.Show("mistake");
            BindingExpression binding = Cash.GetBindingExpression(TextBlock.TextProperty);
            binding.UpdateTarget();
            
            //Amount.Text = "";
        }

     

        private void CashTransferContr_Click(object sender, RoutedEventArgs e)
        {
            float sum = 0;
            if (float.TryParse(Amount2.Text, out sum))
            {
                if (bankA.TransferContr(selected1, selected2, sum)) MessageBox.Show("success");
                else MessageBox.Show("mistake");
            }
            else MessageBox.Show("mistake");
            AccountList.Items.Refresh();
            BindingExpression binding = Cash.GetBindingExpression(TextBlock.TextProperty);
            binding.UpdateTarget();

        }


        private void CashTransferCov_Click(object sender, RoutedEventArgs e)
        {
            float sum = 0;
            if (float.TryParse(Amount2.Text, out sum))
            {
                VariantCov<Account> s1 = new VariantCov<Account>(selected1);
                VariantCov<Account> s2 = new VariantCov<Account>(selected2);
                if (bankA.TransferCov(s1, s2, sum))
                    MessageBox.Show("success");
                else MessageBox.Show("mistake");
            }
            else MessageBox.Show("mistake");
            AccountList.Items.Refresh();
            BindingExpression binding = Cash.GetBindingExpression(TextBlock.TextProperty);
            binding.UpdateTarget();
        }


        private void AnotherAccount_Click(object sender, RoutedEventArgs e)
        {
            selected1 = selected2;
            SourceAccount.Text = selected2.AccountNumber;
        }

        private void ChooseCash_Click(object sender, RoutedEventArgs e)
        {
            selected1 = bankA.cash;
            SourceAccount.Text = bankA.cash.AccountNumber;
        }

       

        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AccountList.UnselectAll();
            Client selectedClient = ClientList.SelectedItem as Client;
            AccountList.ItemsSource = selectedClient.Accounts;
           
            
        }

        private void AccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AccountList.SelectedItem != null) 
            {
                selected2 = AccountList.SelectedItem as Account;
                SelectedAccount.Text = $"{selected2.AccountNumber}";
            }
            
        }

        
    }
}
