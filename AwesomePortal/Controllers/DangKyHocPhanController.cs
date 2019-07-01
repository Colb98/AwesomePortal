using AwesomePortal.API.Request;
using AwesomePortal.API.Response;
using AwesomePortal.Models;
using AwesomePortal.Utils.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Controllers
{
    class DangKyHocPhanController
    {
        // Số lượng tín chỉ đã đăng ký + đang đăng ký (để ko vượt quá tối đa)
        public int currentTC = 0;
        public int maxTC = 0;

        // Mã các học phần vừa mới chọn (để đăng ký)
        public List<string> newEnrolList = new List<string>();

        // Mã các học phần vừa mới chọn (để huỷ)
        public List<string> cancelEnrolList = new List<string>();

        public async Task<bool> SetListCancelled(List<int> listMaMon)
        {
            BaseConnector connector = BaseConnector.getInstance();
            RequestEnrolOrCancel req = new RequestEnrolOrCancel();
            req.subject_ids = listMaMon.ToArray();
            BaseResponse res = await connector.PostObject(DeployEnvironment.GetEnvironment().GetCancelPath(), req);
            return res.status;
        }

        public async Task<bool> SetListEnrol(List<int> listMaMon)
        {
            BaseConnector connector = BaseConnector.getInstance();
            RequestEnrolOrCancel req = new RequestEnrolOrCancel();
            req.subject_ids = listMaMon.ToArray();
            BaseResponse res = await connector.PostObject(DeployEnvironment.GetEnvironment().GetEnrolPath(), req);
            return res.status;
        }

        public void Reset()
        {
            currentTC = 0;
            maxTC = 0;

            newEnrolList.Clear();

            cancelEnrolList.Clear();
        }
    }
}
