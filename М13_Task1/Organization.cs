using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace М13_Task1
{
 
    public class Organization : Client, IClient
    {
        string name;               // Название
        string inn;                // налоговый номер
        string representative;     // представитель



        public Organization(
            string name,
            string inn,
            string representative,
            int idForm) : base(idForm)
        {
            this.name = name;
            this.inn = inn;
            this.representative = representative;
        }


        public string OrganizationName
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string INN
        {
            get { return this.inn; }
            set { this.inn = value; }
        }

        public string Representative
        {
            get { return this.representative; }
            set { this.representative = value; }
        }

        public string Name() { return $"{this.OrganizationName}"; }

        public override string ToString()
        {
            return $"{this.ClientId}:\n" +
                   $"{this.OrganizationName} " +
                   $"ИНН {this.INN} \n" +
                   $"Представитель: {this.representative}";
        }

    }
}
