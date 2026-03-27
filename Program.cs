using System;
using OnlineBankingAppService;
using OnlineBankingModels;

namespace OnlineBanking
{
    class Program()
    {
        static void Main(string[] args)
        {
            char choice;
            do
            {
                BankingBusiness bankingbusiness = new BankingBusiness();


                Console.WriteLine("ONLINE BANKING: LOAN");

                Console.WriteLine("Maximum Loan Amount: Php 100,000");
                Console.WriteLine("Minimum Loan Amount: Php 20,000");
                Console.WriteLine("Flexible payment terms from 1-25 Years");

                Console.Write("Loan Amount: ");
                int loanInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("The Interest is 1.3%");

                Console.Write("Choose a Loan Period (Maximum 25 Years): ");
                int periodInput = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("---------------------------------------");

                BankingModel loan = bankingbusiness.CreateLoan(loanInput, periodInput);

                if (loan == null)
                {
                    Console.WriteLine("Your input is invalid or exceeds limits!");
                }
                else
                {
                    Console.WriteLine("Total Loan Amount: " + loan.LoanAmount);
                    Console.WriteLine("Loan Period: " + loan.LoanPeriod + " Years");
                    Console.WriteLine("Interest Rate: 1.3%");
                    Console.WriteLine("Monthly Payment: Php " + loan.MonthlyPayment);
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("Loan Successfully!");
                }
              
                Console.Write("Do you want to Loan? y/n: ");
                choice = Convert.ToChar(Console.ReadLine());
            }
            while (choice !='n');
        }
    }
}