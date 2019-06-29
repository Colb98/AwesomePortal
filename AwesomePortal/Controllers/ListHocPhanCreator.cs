using AwesomePortal.Models;
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
                List<Object> listO = await connector.GetListObject("listmon");
                for(int i = 0; i < listO.Count; i++)
                {
                    listHocPhan.Add(HocPhan.Parse(listO[i]));
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
