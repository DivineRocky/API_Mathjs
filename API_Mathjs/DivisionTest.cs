using API_Mathjs.DAO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace API_Mathjs
{
    public class DivisionTest
    {
        private IEnumerable<TwoExpressionsTestData> _testData;
        private MathjsProxy _mathjsProxy;
        private const string _filePath = @"C:\TestData\DivisionTestData.txt";    

        [SetUp]
        public void Setup()
        {
            _mathjsProxy = new MathjsProxy();
            _testData = TestdataFileOperations.GetTestDataFromFile(_filePath);
        }

        [Test]
        public void DigitsDivision_DigitsFromFile_ResultsMatchToValidationFile()
        {
            foreach (var testData in _testData)
            {
                var divisionRequest = new DivisionRequest { Expr = new List<string> { $"{testData.FirstExpression}/{testData.SecondExpression}" } };
                CalculatorResponse divisionResult = _mathjsProxy.MakePostRequest(divisionRequest);
                Assert.AreEqual(testData.IsToFail, divisionResult.HasFailed);
                Assert.AreEqual(testData.ExpectedResult, divisionResult.Result?.First());
            }            
        }
    }
}