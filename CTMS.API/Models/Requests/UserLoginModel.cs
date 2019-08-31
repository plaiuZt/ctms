using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMS.API.Models.Requests
{
    public class UserLoginModel
    {
        [JsonProperty(PropertyName ="UserName",NullValueHandling =NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "MobilePhone", NullValueHandling = NullValueHandling.Ignore)]
        public string MobilePhone { get; set; }
        [JsonProperty(PropertyName = "OpenId", NullValueHandling = NullValueHandling.Ignore)]
        public string OpenId { get; set; }
        [JsonProperty(PropertyName = "QQ", NullValueHandling = NullValueHandling.Ignore)]
        public string QQ { get; set; }
        [JsonProperty(PropertyName = "Password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
    }
}
