using API_Mathjs.DAO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace API_Mathjs
{
    public class MathjsProxy
    {
        public CalculatorResponse MakePostRequest(DivisionRequest divisionRequest)
        {
            string url = "http://api.mathjs.org/v4/";
            string json = JsonConvert.SerializeObject(divisionRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = client.PostAsync(url, data).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            CalculatorResponse calculatorResponse = JsonConvert.DeserializeObject<CalculatorResponse>(result);
            return calculatorResponse;
        }
    }
}
