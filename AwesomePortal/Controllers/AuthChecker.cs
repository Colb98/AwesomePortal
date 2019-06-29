using AwesomePortal.Utils;
using AwesomePortal.Utils.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Controllers
{
    class AuthChecker
    {
        class AuthRequest
        {
            public string mssv { get; set; }
            public string password { get; set; }
        }
        public static async Task<bool> sendAuth(string un, string pw)
        {
            BaseConnector connector = BaseConnector.getInstance();
            Object response = await connector.PostObject("/api/auth/login", new AuthRequest() { mssv = un, password = pw });
            return JsonGetter.getBool(response.ToString(), "status");
        }
    }
}
