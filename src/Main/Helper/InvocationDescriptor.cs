using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.Helper
{
    public class InvocationDescriptor
    {
        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonPropertyAttribute("arguments")]
        public object[] Arguments { get; set; }
    }
}