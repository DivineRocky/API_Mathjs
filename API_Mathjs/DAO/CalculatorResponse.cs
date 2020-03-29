using System.Collections.Generic;

namespace API_Mathjs.DAO
{
    public class CalculatorResponse
    {
        public IEnumerable<string> Result { get; set; }

        public string Error { get; set; }

        public bool HasFailed => Error != null;
    }
}
