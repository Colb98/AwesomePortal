using AwesomePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Utils.Connectors
{
    class DeployEnvironment
    {
        public virtual string GetLoginPath()
        {
            return "auth/login";
        }
        public virtual string GetStudentInfoPath(string mssv)
        {
            return "students/" + mssv;
        }
        public virtual string GetTryEnrolPath()
        {
            return "students/" + SinhVien.getInstance().mssv + "/try_enrolls/already";
        }
        public virtual string GetEnrolablePath()
        {
            return "students/" + SinhVien.getInstance().mssv + "/try_enrolls/can";
        }
        public virtual string GetUnEnrolablePath()
        {
            return "students/" + SinhVien.getInstance().mssv + "/try_enrolls/not";
        }
        public virtual string GetCancelPath()
        {
            return "try_enrolls/delete";
        }
        public virtual string GetEnrolPath()
        {
            return "try_enrolls";
        }

        public virtual string GetURL()
        {
            return "https://pttkpm-cntn16-portal.herokuapp.com/";
        }

        public static DeployEnvironment GetEnvironment()
        {
            switch (LocalOrPublic.MODE)
            {
                case LocalOrPublic.MODE_LOCAL:
                    return new LocalEnvironment();
                case LocalOrPublic.MODE_PUBLIC:
                    return new DeployEnvironment();
                default:
                    return new DeployEnvironment();
            }
        }
    }
}
