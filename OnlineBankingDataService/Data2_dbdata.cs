using System;
using OnlineBankingModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace OnlineBankingDataService
{
    public class Data2_dbdata: Info_loan
    {
        private string connectionString
            = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = db_loans; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public Data2_dbdata()
        {
            sqlConnection = new SqlConnection(connectionString);
            AddSeeds();
        }
        private void AddSeeds()
        {
            var existing = GetLoans();
            if (existing.Count == 0)
            {
                BankingModel bm = new BankingModel
                {
                    LoanId = Guid.NewGuid(),
                    LoanAmount = 10000,
                    LoanPeriod = 3,
                    MonthlyPayment = 349.46
                };
                Add(bm);

            }
        }
            public void Add(BankingModel bmodels)
        {
            var insertStatement = "INSERT INTO tbl_linfo VALUES (@LoanId,@LoanAmount,@LoanPeriod,@MonthlyPayment)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@LoanId", bmodels.LoanId);
            insertCommand.Parameters.AddWithValue("@LoanAmount", bmodels.LoanAmount);
            insertCommand.Parameters.AddWithValue("@LoanPeriod", bmodels.LoanPeriod);
            insertCommand.Parameters.AddWithValue("@MonthlyPayment", bmodels.MonthlyPayment);
            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
            }       
        
            public List<BankingModel> GetLoans()
        {
            var loans = new List<BankingModel>();

            var selectStatement = "SELECT LoanId, LoanAmount, LoanPeriod, MonthlyPayment FROM tbl_linfo";
            SqlCommand command = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                    BankingModel bmw = new BankingModel();
                    bmw.LoanId = reader.GetGuid(0);
                    bmw.LoanAmount = Convert.ToInt32(reader["LoanAmount"]);
                    bmw.LoanPeriod = Convert.ToInt32(reader["LoanPeriod"]);
                    bmw.MonthlyPayment = Convert.ToDouble(reader["MonthlyPayment"]);
                loans.Add(bmw);
            }

            sqlConnection.Close();

            return loans;
        }
        public void DeleteLoans(Guid id)
        {
            sqlConnection.Open();
            var updateStatement = $"DELETE FROM tbl_linfo WHERE LoanId = @LoanId";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@LoanId", id);


            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public void EditLoans(BankingModel bm)
        {
            sqlConnection.Open();

            var updateStatement = $"UPDATE tbl_linfo SET LoanId = @LoanId, LoanPeriod = @LoanPeriod WHERE LoanId = @LoanId";

            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            updateCommand.Parameters.AddWithValue("@LoanId", bm.LoanId);
            updateCommand.Parameters.AddWithValue("@LoanPeriod", bm.LoanPeriod);


            updateCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public BankingModel? ReceiptLoans(Guid id)
        {
            return GetLoans().FirstOrDefault(t => t.LoanId == id);
        }
    }
}
