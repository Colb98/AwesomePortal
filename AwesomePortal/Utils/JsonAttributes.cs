using System;
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 

namespace AwesomePortal.Utils
{
    public class JsonAttributes
    {
        public virtual string SV() { return "student"; }
        public virtual string SV_ID  () { return  "id"; }
        public virtual string SV_MSSV () { return  "mssv"; }
        public virtual string SV_TEN  () { return  "name"; }
        public virtual string SV_CHUONGTRINH  () { return  "program"; }
        public virtual string SV_KHOA  () { return  "fal"; }
        public virtual string SV_KHOATUYEN  () { return  "year"; }
        public virtual string SV_MAXTC  () { return  "maxValue"; }
        public virtual string SV_DKHP  () { return  "dkhp"; }

        public virtual string TG_THU  () { return  "thu"; }
        public virtual string TG_TIETBD  () { return  "tietbd"; }
        public virtual string TG_TIETKT() { return "tietkt"; }

        public virtual string HP_ID  () { return  "id"; }
        public virtual string HP_MA  () { return  "maHP"; }
        public virtual string HP_TEN  () { return  "tenHP"; }
        public virtual string HP_NAM  () { return  "namHoc"; }
        public virtual string HP_LOP() { return "lop"; }
        public virtual string HP_MAXSV  () { return  "maxSV"; }
        public virtual string HP_DK  () { return  "dkSV"; }
        public virtual string HP_SOTC  () { return  "soTC"; }
        public virtual string HP_HOCKY  () { return  "hocKy"; }

        public virtual string D_GK  () { return  "gk"; }
        public virtual string D_CK  () { return  "ck"; }
        public virtual string D_TK  () { return  "tk"; }

        public virtual string DKHP_D  () { return  "diem"; }
        public virtual string DKHP_HP  () { return  "hocphan"; }

        public virtual string RES_STATUS  () { return  "status"; }
        public virtual string RES_DATA  () { return  "data"; }
        public virtual string RES_RESULT  () { return  "result"; }
        public virtual string RES_REASON  () { return  "lyDo"; }
        public virtual string RES_SUBJECT() { return "subject"; }
    }
}
