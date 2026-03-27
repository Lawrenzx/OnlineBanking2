using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using OnlineBankingModels;

namespace OnlineBankingDataService
{
    public class DataJson:Info_loan
    {
        private List<BankingModel> bmw = new List<BankingModel>();
        private string _jsonFileName;
        public DataJson()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/datajson.json";
            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (bmw.Count <= 0)
            {
                bmw.Add(new BankingModel { LoanId = Guid.NewGuid(), LoanAmount = 10000, LoanPeriod = 3,MonthlyPayment = 349.46 });


                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<BankingModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , bmw);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(this._jsonFileName))
            {
                this.bmw = JsonSerializer.Deserialize<List<BankingModel>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }
        public void Add(BankingModel bankingmodel)
        {
            bmw.Add(bankingmodel);
            SaveDataToJsonFile();
        }
        public List<BankingModel> GetLoans()
        {
            RetrieveDataFromJsonFile();
            return bmw;
        }
      
    }
}
