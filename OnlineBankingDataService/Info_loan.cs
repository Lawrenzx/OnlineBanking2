using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBankingModels;

namespace OnlineBankingDataService
{
    public interface Info_loan
    {
        void Add(BankingModel bmmodels);
        List<BankingModel> GetLoans();

    }
}
