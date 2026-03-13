using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBankingDataService;
using OnlineBankingModels;

namespace OnlineBankingAppService
{
    public class BankingBusiness
    {
        BankingData bankingdata = new BankingData();
        public BankingModel? CreateLoan(double loanAmount, int periodYears)
        {
            if (loanAmount < 20000 || loanAmount > 100000)
                return null;

            if (periodYears < 1 || periodYears > 25)
                return null;

            double monthlyRate = 0.013 / 100 / 12;

            int totalPayments = periodYears * 12;

            double monthlyPay =
                loanAmount *
                (monthlyRate * Math.Pow(1 + monthlyRate, totalPayments)) /
                (Math.Pow(1 + monthlyRate, totalPayments) - 1);

            double payment = Math.Round(monthlyPay, 2);

            BankingModel loan = new BankingModel
            {
                LoanId = Guid.NewGuid(),
                LoanAmount = loanAmount,
                LoanPeriod = periodYears,
                MonthlyPayment = payment
            };

            bankingdata.AddLoan(loan);

            return loan;
        }
    }
}
      
