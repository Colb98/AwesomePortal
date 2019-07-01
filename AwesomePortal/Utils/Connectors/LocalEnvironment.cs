using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Utils.Connectors
{
    class LocalEnvironment : DeployEnvironment
    {
        public override string GetCancelPath()
        {
            return "cancel";
        }

        public override string GetEnrolablePath()
        {
            return "listmonchuadk";
        }

        public override string GetEnrolPath()
        {
            return "enrol";
        }

        public override string GetLoginPath()
        {
            return "api/auth/login";
        }

        public override string GetStudentInfoPath(string mssv)
        {
            return "sinhvien";
        }

        public override string GetTryEnrolPath()
        {
            return "listmon";
        }

        public override string GetUnEnrolablePath()
        {
            return "listmonkhongthedk";
        }

        public override string GetURL()
        {
            return "http://localhost:3000/";
        }
    }
}
