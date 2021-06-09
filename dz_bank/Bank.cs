using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_bank
{
    /// <summary>
    /// Банк, который хранит ID клиентов
    /// </summary>
    public abstract class Bank
    {
        public string NameBank { get; set; } 
      
        public Bank(string Name)
        {                    
            this.NameBank = Name;      
        }
 

    }
}
