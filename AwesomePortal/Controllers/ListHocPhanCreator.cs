using AwesomePortal.API.Response;
using AwesomePortal.Models;
using AwesomePortal.Utils;
using AwesomePortal.Utils.Connectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Controllers
{
    class ListHocPhanCreator
    {
        private SinhVien sinhVien;
        public ListHocPhanCreator()
        {

        }

        public class HocPhanExtend
        {
            public HocPhan hocPhan { get; set; }
            // Lý do không được phép đăng ký
            public string lyDo { get; set; }
        }

        public ListHocPhanCreator(SinhVien sv)
        {
            sinhVien = sv;
        }

        public async Task<List<HocPhan>> getListRegisteredAsync()
        {
            try
            {
                List<HocPhan> listHocPhan = new List<HocPhan>();
                BaseConnector connector = BaseConnector.getInstance();
                BaseResponse res = await connector.GetObject(DeployEnvironment.GetEnvironment().GetTryEnrolPath());
                if (res.status)
                {
                    JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();
                    List<Object> listO = JsonGetter.getList(res.obj.ToString(), jsonAttr.RES_RESULT());
                    for (int i = 0; i < listO.Count; i++)
                    {
                        listHocPhan.Add(HocPhan.Parse(JsonGetter.getObject(listO[i].ToString(), jsonAttr.RES_SUBJECT())));
                    }
                }
                return listHocPhan;
            }
            catch (Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }

        public async Task<List<HocPhan>> getListRegistableAsync()
        {
            try
            {
                List<HocPhan> listHocPhan = new List<HocPhan>();
                BaseConnector connector = BaseConnector.getInstance();
                BaseResponse res = await connector.GetObject(DeployEnvironment.GetEnvironment().GetEnrolablePath());
                if (res.status)
                {
                    JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();
                    List<Object> listO = JsonGetter.getList(res.obj.ToString(), jsonAttr.RES_RESULT());
                    for (int i = 0; i < listO.Count; i++)
                    {
                        listHocPhan.Add(HocPhan.Parse(JsonGetter.getObject(listO[i].ToString(), jsonAttr.RES_SUBJECT())));
                    }
                }
                return listHocPhan;
            }
            catch (Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }

        public async Task<List<HocPhanExtend>> getListUnRegistableAsync()
        {
            try
            {
                List<HocPhanExtend> listHocPhan = new List<HocPhanExtend>();
                BaseConnector connector = BaseConnector.getInstance();
                BaseResponse res = await connector.GetObject(DeployEnvironment.GetEnvironment().GetUnEnrolablePath());
                if (res.status)
                {
                    JsonAttributes jsonAttr = JsonAttributeGetter.GetJsonAttributes();
                    List<Object> listO = JsonGetter.getList(res.obj.ToString(), jsonAttr.RES_RESULT());
                    for (int i = 0; i < listO.Count; i++)
                    {
                        HocPhanExtend hocPhan = new HocPhanExtend()
                        {
                            hocPhan = HocPhan.Parse(JsonGetter.getObject(listO[i].ToString(), jsonAttr.RES_SUBJECT())),
                            lyDo = JsonGetter.getString(listO[i].ToString(), jsonAttr.RES_REASON())
                        };
                        listHocPhan.Add(hocPhan);
                    }
                }
                return listHocPhan;
            }
            catch (Exception ex)
            {
                LogHelper.Log("ERROR: " + ex);
                return null;
            }
        }
    }
}
