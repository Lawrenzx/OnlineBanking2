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

            Console.Write("Choose a Loan Period (6, 12, 18, 24, 36 Months:");
            int periodInput = Convert.ToInt16(Console.ReadLine());

            if (loanInput == 20000 && periodInput == 6 ||
                loanInput == 20000 && periodInput == 12 ||
                loanInput == 20000 && periodInput == 18 ||
                loanInput == 20000 && periodInput == 24 ||
                loanInput == 20000 && periodInput == 36)
            {
                Console.WriteLine("Total Loan Amount: " + loanInput);
                Console.WriteLine("Loan Period: " + periodInput);
                Console.WriteLine("Interest Rate: 1.3%");
                Console.WriteLine("Monthly Payment: ");
            }
            else if (loanInput <= 50000 && periodInput == 6 ||
                loanInput <= 50000 && periodInput == 12 ||
                loanInput <= 50000 && periodInput == 18 ||
                loanInput <= 50000 && periodInput == 24 ||
                loanInput <= 50000 && periodInput == 36)
            {
                Console.WriteLine("Total Loan Amount: " + loanInput);
                Console.WriteLine("Loan Period: " + periodInput);
                Console.WriteLine("Interest Rate: 1.3%");
                Console.WriteLine("Monthly Payment: ");
            }
            else if (loanInput <= 100000 && periodInput == 6 ||
                loanInput <= 100000 && periodInput == 12 ||
                loanInput <= 100000 && periodInput == 18 ||
                loanInput <= 100000 && periodInput == 24 ||
                loanInput <= 100000 && periodInput == 36)
            {
                Console.WriteLine("Total Loan Amount: " + loanInput);
                Console.WriteLine("Loan Period: " + periodInput);
                Console.WriteLine("Interest Rate: 1.3%");
                Console.WriteLine("Monthly Payment: ");
            }
            else
            {
                Console.WriteLine("Your Input is Invalid or Limit!, Try Again!");

            }
        }
    }
}