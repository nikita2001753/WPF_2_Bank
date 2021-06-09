using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_bank
{
   public class bank_data 
    {
        string [] messageOtdelov = new string[3] {"Юр лица", "VIP клиенты", "Обычные клиенты" };

        static Random r = new Random();

        
        Bank bankChTZ { get; set; }
        public List<BankClient> BankClients { get; set; }

        /// <summary>
        /// отдулы банка
        /// </summary>
        public List<Departaments> DepartamentsBank { get; set; }

        private bank_data(int number_of_customer_divisions, int CountClients)
        {
            BankClients = new List<BankClient>();
            //bankChTZ = new Bank("БанкЧТЗ");
            DepartamentsBank = new List<Departaments>();

            //создаю 3 отдела юр вип обычные 0 - юр 1 - VIP 2 - обычные
            for (int i = 0; i < number_of_customer_divisions; i++)
            {
                DepartamentsBank.Add(new Departaments($"{messageOtdelov[i]} ", i));
            }

            //разбрасываем клиентов по отделам ( 3 отдела ) с помощью ID
            for (int i = 0; i < CountClients; i++)
            {
                BankClients.Add(
                        new BankClient($"Имя_{i + 1}",
                                     r.Next(16,80),
                                     r.Next(3000, 1000000),
                                     r.Next(DepartamentsBank.Count)));
            }

        }

        
        public static bank_data CreateBankData(int number_of_customer_divisions = 3, int CountClients = 60)
        {
            return new bank_data(number_of_customer_divisions, CountClients);
        }

        /// <summary>
        /// Денежные транзакции между клиентами
        /// </summary>
        /// <param name="NameOtp"></param>
        /// <param name="CountSumma"></param>
        /// <param name="NamePolu"></param>
        public void Perevod (string NameOtp, int CountSumma, string NamePolu)
        {          
            for (int i = 0; i < BankClients.Count; i++)
            {
                if (NameOtp == BankClients[i].Name)
                {                   
                    int balansOtprav = BankClients[i].GetMoney();
                   

                    if ( (BankClients[i].GetMoney() - CountSumma) >= 0)
                    {                  
                        balansOtprav -= CountSumma;
                        BankClients[i].SetMoney(balansOtprav);

                        for (int j = 0; j < BankClients.Count; j++)
                        {
                            int balansPoluch;
                            if (NamePolu == BankClients[j].Name )
                            {
                                balansPoluch = BankClients[j].GetMoney();
                                balansPoluch += CountSumma;
                                BankClients[j].SetMoney(balansPoluch);
                                break;
                            }
                        }

                      
                    }

                    else break;                         
                }
            }
        }

        /// <summary>
        /// Капитализаций 12% годовых
        /// </summary>
        public void Kapitalize(string NameClienta)
        {
            for (int i = 0; i < BankClients.Count; i++)
            {

                if (NameClienta == BankClients[i].Name)
                {
                    double SummaClientaInBank = BankClients[i].Money;
                    double kapitaliz;
                    for (int j = 0; j < 12; j++)
                    {
                        kapitaliz = (SummaClientaInBank  * 0.12)/12;
                        SummaClientaInBank += kapitaliz;
                    }

                    BankClients[i].Money = (int)SummaClientaInBank;

                }
            }
        }
    }
}
