using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBankingModels
{
    public class BankingModel
    {
        public Guid LoanId { get; set; }

        public double LoanAmount { get; set; }

        public int LoanPeriod { get; set; }

        public double MonthlyPayment { get; set; }

    }
}
