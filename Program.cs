using System;

namespace Loan
{
    internal class Program()
    {
        static void Main(string[] args)
        {


            Console.WriteLine("ONLINE BANKING: LOAN");

            Console.WriteLine("Maximum Loan Amount: Php 100,000");
            Console.WriteLine("Minimum Loan Amount: Php 20,000");
            Console.WriteLine("Flexible payment terms from 6-60 months");

            Console.Write("Loan Amount: ");
            int loanInput = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("The Interest is 1.3%");

            Console.Write("Choose a Loan Period (Maximum 25 Years):");
            int periodInput = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("--------------------------------------------------");

            if (loanInput == 20000 && periodInput <= 5 ||
                loanInput == 20000 && periodInput <= 10||
                loanInput == 20000 && periodInput <= 15 ||
                loanInput == 20000 && periodInput <= 20 ||
                loanInput == 20000 && periodInput <= 25 )
            {
                double monthlyRate = 0.013 / 100 / 12;
                int totalPayments = periodInput * 12;
                double monthlyPay = loanInput * (monthlyRate * Math.Pow(1 + monthlyRate, totalPayments)) / (Math.Pow(1 + monthlyRate, totalPayments) - 1);
                double payment = Math.Round(monthlyPay, 2);

                Console.WriteLine("Total Loan Amount: " + loanInput);
                Console.WriteLine("Loan Period: " + periodInput + "Years");
                Console.WriteLine("Interest Rate: 1.3%");
                Console.WriteLine("Monthly Payment: " + payment);
            }
            else if (loanInput <= 50000 && periodInput <= 5 ||
                loanInput <= 50000 && periodInput <= 10 ||
                loanInput <= 50000 && periodInput <= 15 ||
                loanInput <= 50000 && periodInput <= 20 ||
                loanInput <= 50000 && periodInput <= 25)
            {
                double monthlyRate = 0.013 / 100 / 12;
                int totalPayments = periodInput * 12;
                double monthlyPay = loanInput * (monthlyRate * Math.Pow(1 + monthlyRate, totalPayments)) / (Math.Pow(1 + monthlyRate, totalPayments) - 1);
                double payment = Math.Round(monthlyPay, 2);

                Console.WriteLine("Total Loan Amount: " + loanInput);
                Console.WriteLine("Loan Period: " + periodInput + "Years");
                Console.WriteLine("Interest Rate: 1.3%");
                Console.WriteLine("Monthly Payment: " + payment);
            }
            else if (loanInput <= 100000 && periodInput <= 5 ||
                loanInput <= 100000 && periodInput <= 10 ||
                loanInput <= 100000 && periodInput <= 15 ||
                loanInput <= 100000 && periodInput <= 20 ||
                loanInput <= 100000 && periodInput <= 25)
            {
                double monthlyRate = 0.013 / 100 / 12;
                int totalPayments = periodInput * 12;
                double monthlyPay = loanInput * (monthlyRate * Math.Pow(1 + monthlyRate, totalPayments)) / (Math.Pow(1 + monthlyRate, totalPayments) - 1);
                double payment = Math.Round(monthlyPay, 2);

                Console.WriteLine("Total Loan Amount: " + loanInput);
                Console.WriteLine("Loan Period: " + periodInput + "Years");
                Console.WriteLine("Interest Rate: 1.3%");
                Console.WriteLine("Monthly Payment: " + payment);
            }
            else
            {
                Console.WriteLine("Your Input is Invalid or Limit!, Try Again!");

            }
        }
        
    }
}