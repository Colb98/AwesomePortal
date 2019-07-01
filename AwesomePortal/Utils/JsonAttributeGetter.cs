using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal.Utils
{
    class JsonAttributeGetter
    {
        public static JsonAttributes GetJsonAttributes()
        {
            switch (LocalOrPublic.MODE)
            {
                case LocalOrPublic.MODE_LOCAL:
                    return new JsonAttributes();
                case LocalOrPublic.MODE_PUBLIC:
                    return new JsonAttributesLive();
                default:
                    return new JsonAttributesLive();
            }
        }
    }
}
