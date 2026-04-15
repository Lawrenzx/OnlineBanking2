using OnlineBankingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingDataService
{
    public class DataServe
    {
        Info_loan info_Loan;

        public DataServe(Info_loan dataserve)
        {
            info_Loan = dataserve;
        }
        public void Add(BankingModel bankingmodel)
        {
            info_Loan.Add(bankingmodel);
        }
        public void DeleteLoans(Guid id) {
            info_Loan.DeleteLoans(id);
        }
        public void EditLoans(BankingModel bm) {
            info_Loan.EditLoans(bm);
        }
        public BankingModel? ReceiptLoans(Guid id) {
           return  info_Loan.ReceiptLoans(id);
        }
        public List<BankingModel> GetLoans()
        {
            return info_Loan.GetLoans();
        }
    }
}