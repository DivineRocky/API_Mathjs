using API_Mathjs.DAO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace API_Mathjs
{
    public class TestdataFileOperations
    {
        public static IEnumerable<TwoExpressionsTestData> GetTestDataFromFile(string filePath)
        {
            string jsonTestData = File.ReadAllText(filePath);
            IEnumerable<TwoExpressionsTestData> dataFromFile = JsonConvert.DeserializeObject<IEnumerable<TwoExpressionsTestData>>(jsonTestData);
            return dataFromFile;
        }

        public static void CreateTestData(string filePath)
        {
            var testData = new List<TwoExpressionsTestData>
            {
                new TwoExpressionsTestData {FirstExpression = "5", SecondExpression = "0", ExpectedResult = "Infinity", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "0", SecondExpression = "0", ExpectedResult = "NaN", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "?", SecondExpression = "DFGD", ExpectedResult = null, IsToFail = true},
                new TwoExpressionsTestData {FirstExpression = "5/", SecondExpression = "2", ExpectedResult = null, IsToFail = true},
                new TwoExpressionsTestData {FirstExpression = "5.5", SecondExpression = "2.25", ExpectedResult = "2.4444444444444446", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "5,5", SecondExpression = "2,25", ExpectedResult = null, IsToFail = true},
                new TwoExpressionsTestData {FirstExpression = "10", SecondExpression = "1.56784", ExpectedResult = "6.378201857332381", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "(3/4)", SecondExpression = "(4/6)", ExpectedResult = "1.125", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "-3", SecondExpression = "-5", ExpectedResult = "0.6", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "-2+5", SecondExpression = "-6+9", ExpectedResult = "6.166666666666666", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "(-2+5)", SecondExpression = "(-6+9)", ExpectedResult = "1", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "10000000000000000", SecondExpression = "0.45828565", ExpectedResult = "2.182045193865442e+16", IsToFail = false},
                new TwoExpressionsTestData {FirstExpression = "0.0000000000543", SecondExpression = "2383!", ExpectedResult = "0", IsToFail = false},
            };

            string testDataJson = JsonConvert.SerializeObject(testData);
            File.WriteAllText(filePath, testDataJson, Encoding.UTF8);
        }
    }
}
