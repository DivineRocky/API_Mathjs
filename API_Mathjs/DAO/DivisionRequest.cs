using Newtonsoft.Json;
using System.Collections.Generic;

namespace API_Mathjs.DAO
{
    public class DivisionRequest
    {
        [JsonProperty("expr")]
        public IEnumerable<string> Expr { get; set; }
    }
}