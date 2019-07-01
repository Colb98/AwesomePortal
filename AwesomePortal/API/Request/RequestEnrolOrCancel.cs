using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.API.Request
{
    class RequestEnrolOrCancel
    {
        public int student_id = Models.SinhVien.getInstance().id;
        public int[] subject_ids;
    }
}
