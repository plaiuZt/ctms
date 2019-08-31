using CTMS.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMS.API.Models.Responses
{
    public class LoginUserModel
    {
        public string Token { get; set; }
        public long Id { get; set; }
        public UserType UserType { get; set; }
        public string UserName { get; set; }
        public string OpenId { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public string MobilePhone { get; set; }
    }
}
