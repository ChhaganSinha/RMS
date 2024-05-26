using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Dto.Auth
{
    public class UserInfo
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public Dictionary<string, string> ExposedClaims { get; set; }

        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }

    }
}
