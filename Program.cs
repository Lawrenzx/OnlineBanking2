using OnlineBankingAppService;
using OnlineBankingModels;
using System;
using static Microsoft.Data.SqlClient.Internal.SqlClientEventSource;

namespace OnlineBanking
{
    class Program()
    {
  
        static void Main(string[] args)
        {

            char choice;
            short Menu = 0;
            do
            {
            
                BankingBusiness bankingbusiness = new BankingBusiness();


                Console.WriteLine("ONLINE BANKING: LOAN");

                Console.WriteLine("Maximum Loan Amount: Php 100,000");
                Console.WriteLine("Minimum Loan Amount: Php 20,000");
                Console.WriteLine("Flexible payment terms from 1-25 Years");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("LOAN MENU:");
                Console.WriteLine("1. Apply Loan");
                Console.WriteLine("2. Loan History");
                Console.WriteLine("3. Loan to cancel");
                Console.WriteLine("4. Edit a Loan Period");
                Console.WriteLine("5. Receipt of Loan");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Choose a number from menu (1-5): ");
                Menu = Convert.ToInt16(Console.ReadLine());
                




                switch (Menu)
                {
                    case 1:
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
                        break;
                    case 2:
                        var lo = bankingbusiness.GetLoans();
                        Console.WriteLine("LOAN HISTORY");
                        Console.WriteLine("---------------------------------------");
                        if (lo.Count == 0)
                        {
                            Console.WriteLine("No Loans available.");
                            return;
                        }
                        else
                        {
                            for (int i = 0; i < lo.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {lo[i].LoanAmount}");

                            }
                            Console.WriteLine("-------------------------");
                        }
                        break;

                    case 3:
                        var ca = bankingbusiness.GetLoans();
                        if (ca.Count == 0)
                        {
                            Console.WriteLine("No Loans available.");
                            Console.WriteLine("-------------------------");
                            return;
                        }

                        for (int i = 0; i < ca.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {ca[i].LoanAmount}");
                        }

                        Console.Write("Select Loan number to cancel: ");
                        int index = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (index < 0 || index >= ca.Count)
                        {
                            Console.WriteLine("Invalid selection.");
                            Console.WriteLine("-------------------------");
                            return;
                        }

                        Guid selectedId = ca[index].LoanId;

                        bankingbusiness.DeleteLoans(selectedId);

                        Console.WriteLine("Loan Canceled!");
                        Console.WriteLine("-------------------------");
                        break;

                    case 4:
                        var el = bankingbusiness.GetLoans();

                        if (el.Count == 0)
                        {
                            Console.WriteLine("No Loans available.");
                            Console.WriteLine("-------------------------");
                            return;
                        }


                        for (int i = 0; i < el.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. " + "Loan Amount: Php "+$" {el[i].LoanAmount} " + " Loan Period: " + $"{el[i].LoanPeriod}" +" years.");
                            Console.WriteLine("------------------------------------------------------------------------------");
                        }

                        Console.Write("Select Loan number to edit: ");
                        int indexx = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (indexx < 0 || indexx >= el.Count)
                        {
                            Console.WriteLine("Invalid selection.");
                            Console.WriteLine("-------------------------");
                            return;
                        }


                        Guid id = el[indexx].LoanId;

                        Console.Write("Enter new Loan Period: ");
                        int newP = Convert.ToInt32(Console.ReadLine());

                        bankingbusiness.EditLoans(id, newP);

                        Console.WriteLine("Loan Period updated!");
                        Console.WriteLine("-------------------------");
                        break;

                    case 5:
                        var ll = bankingbusiness.GetLoans();
                       
                        Console.WriteLine("LOAN HISTORY");
                        Console.WriteLine("---------------------------------------");
                        if (ll.Count == 0)
                        {
                            Console.WriteLine("No Loans available.");
                            return;
                        }
                        else
                        {
                            for (int i = 0; i < ll.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {ll[i].LoanAmount}");

                            }
                            Console.WriteLine("-------------------------");
                        }
                        Console.Write("Select Loan number to view receipt: ");
                        int ind = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (ind < 0 || ind >= ll.Count)
                        {
                            Console.WriteLine("Invalid selection.");
                            Console.WriteLine("-------------------------");
                            return;
                        }

                        Guid Id = ll[ind].LoanId;

                       var loans = bankingbusiness.ReceiptLoans(Id);

                        if (loans == null)
                        {
                            Console.WriteLine("Loan not found.");
                        }
                        else
                        {
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine("LOAN RECEIPT");
                            Console.WriteLine("---------------------------------------");
                            Console.WriteLine("Total Loan Amount: " + loans.LoanAmount);
                            Console.WriteLine("Loan Period: " + loans.LoanPeriod + " Years");
                            Console.WriteLine("Interest Rate: 1.3%");
                            Console.WriteLine("Monthly Payment: Php " + loans.MonthlyPayment);
                            Console.WriteLine("---------------------------------------");
                        }
                        //foreach (var jj in ll)
                        //{
                        //    Console.WriteLine("Total Loan Amount: " + jj.LoanAmount);
                        //    Console.WriteLine("Loan Period: " + jj.LoanPeriod + " Years");
                        //    Console.WriteLine("Interest Rate: 1.3%");
                        //    Console.WriteLine("Monthly Payment: Php " + jj.MonthlyPayment);
                        //    Console.WriteLine("---------------------------------------");
                        //}


                        break;
                }
                Console.Write("Do you want to Loan? y/n: ");
                choice = Convert.ToChar(Console.ReadLine());
            }
            while (choice != 'n');


        }
    }
}
    