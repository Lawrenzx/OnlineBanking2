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
        void DeleteLoans(Guid id);
        void EditLoans(BankingModel bm);
        BankingModel? ReceiptLoans(Guid id);
        List<BankingModel> GetLoans();

    }
}
