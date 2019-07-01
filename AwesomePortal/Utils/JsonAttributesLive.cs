using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Utils
{
    class JsonAttributesLive : JsonAttributes
    {
        public virtual string SV                 (){ return "student"; }
        public override string SV_ID             (){ return "id"; }
        public override string SV_MSSV           (){ return "mssv"; }
        public override string SV_TEN            (){ return "name"; }
        public override string SV_CHUONGTRINH    (){ return "program_long"; }
        public override string SV_KHOA           (){ return  "faculty_long"; }
        public override string SV_KHOATUYEN      (){ return  "year"; }
        public override string SV_MAXTC          (){ return  "max_value"; }
        public override string SV_DKHP           (){ return  "results"; }

        public override string TG_THU            (){ return  "weekday"; }
        public override string TG_TIETBD           (){ return  "from_period"; }
        public override string TG_TIETKT() { return "to_period"; }

        public override string HP_ID             (){ return  "id"; }
        public override string HP_MA             (){ return  "mhp"; }
        public override string HP_TEN            (){ return  "name"; }
        public override string HP_LOP            (){ return "class"; }
        public override string HP_NAM            (){ return  "year"; }
        public override string HP_MAXSV          (){ return  "max_student"; }
        public override string HP_DK             (){ return  "count_student"; }
        public override string HP_SOTC           (){ return  "value"; }
        public override string HP_HOCKY          (){ return  "semester"; }
        
        public override string D_GK              (){ return  "midterm"; }
        public override string D_CK              (){ return  "endterm"; }
        public override string D_TK              (){ return  "final"; }

        public override string DKHP_D            (){ return  "score"; }
        public override string DKHP_HP           (){ return  "subject"; }

        public override string RES_STATUS        (){ return  "status"; }
        public override string RES_DATA          (){ return  "data"; }
        public override string RES_RESULT        (){ return  "results"; }
        public override string RES_REASON        (){ return  "lyDo"; }
        public override string RES_SUBJECT() { return "subject"; }
    }
}
