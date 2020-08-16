using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2CDevSync.Models
{
    public class GraphError
    {
        [JsonProperty(PropertyName = "error")]
        public ResponseError Error { get; set; }
    }

    //error object
    public class ResponseError
    {
        [JsonProperty(PropertyName = "code")]
        public string Code;

        [JsonProperty(PropertyName = "message")]
        public string Message;

        [JsonProperty(PropertyName = "innerError")]
        public InnerError InnerError;
    }

    public class InnerError
    {
        [JsonProperty(PropertyName = "request-id")]
        public string RequestId;

        [JsonProperty(PropertyName = "date")]
        public DateTime Date;
    }
}
