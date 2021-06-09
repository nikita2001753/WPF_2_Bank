using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_bank
{
    /// <summary>
    /// Клиент банка
    /// </summary>
    public class BankClient
    {
        public string Name { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Деньги клиента
        /// </summary>
        public int Money { get; set; }

        public int GetMoney()
        {
            return Money;
        }

        public void SetMoney(int Money)
        {
            this.Money = Money;
        }

        public int DepartmentId { get; set; }

        public BankClient(string Name, int Age, int Money,int DepartmentId)
        {
            this.Name = Name;
            this.Age = Age;
            this.Money = Money;
            this.DepartmentId = DepartmentId;
        }

    }
}
