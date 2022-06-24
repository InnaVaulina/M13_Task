using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace М13_Task1
{
 
    public class Businessman : Person
    {
        string inn;        // налоговый номер

        public Businessman(
            string familyName,
            string firstName,
            string patronymicName,
            string inn,
            int idForm) : base(familyName, firstName, patronymicName, idForm)
        { this.inn = inn; }



        public string INN
        {
            get { return this.inn; }
            set { this.inn = value; }
        }

        public new string Name() { return $"ИП {base.Name()}"; }

        public override string ToString()
        {

            return $"{this.ClientId}:\n" +
                   $"{this.Name()} ИНН {this.INN}";
                  
        }

    }
}
