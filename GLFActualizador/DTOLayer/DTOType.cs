using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOType
    {
        private Int32 _idType;
        private String _type;

        public DTOType()
        {
            this._idType = 0;
            this._type = "";
        }

        public Int32 IdType
        {
            get { return _idType; }
            set { _idType = value; }
        }

        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
