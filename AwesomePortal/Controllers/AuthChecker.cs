using AwesomePortal.API.Request;
using AwesomePortal.API.Response;
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
        public static async Task<bool> sendAuth(string un, string pw)
        {
            BaseConnector connector = BaseConnector.getInstance();
            BaseResponse res = await connector.PostObject(DeployEnvironment.GetEnvironment().GetLoginPath(), new AuthRequest() { mssv = un, password = pw });
            return res.status;
        }
    }
}
