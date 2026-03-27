using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBankingModels;

namespace OnlineBankingDataService
{
    public class InMemoryData
    {
        public List<BankingModel> banking = new List<BankingModel>();

        public void AddLoan(BankingModel loan)
        {
           banking.Add(loan);
        }
     
        public List<BankingModel> GetLoans()
        {
            return banking;
        }


    }
}
