using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace М13_Task1
{
   
    /// <summary>
    /// данные о клиентах
    /// </summary>
    public class Person : Client, IClient
    {
        string familyName;         // фамилия
        string firstName;          // имя
        string patronymicName;     // отчество


        public Person(
            string familyName,
            string firstName,
            string patronymicName,
            int idForm) : base(idForm)
        {
            this.familyName = familyName;
            this.firstName = firstName;
            this.patronymicName = patronymicName;
        }


        public string FamilyName
        {
            get { return this.familyName; }
            set { this.familyName = value; }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string PatronymicName
        {
            get { return this.patronymicName; }
            set { this.patronymicName = value; }
        }

        public string Name()
        {
            return $"{this.FamilyName} " +
                   $"{this.FirstName} " +
                   $"{this.PatronymicName} ";
        }



        public override string ToString()
        {
            return base.ToString() + 
                   $"\n{this.FamilyName} " +
                   $"{this.FirstName} " +
                   $"{this.PatronymicName}";
        }
    }
}
