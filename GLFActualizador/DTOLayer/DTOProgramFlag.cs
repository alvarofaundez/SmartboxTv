using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOProgramFlag
    {
        Int64 _idProgramFlag;
        String _name;
        String _pname;
        String _description;

        public DTOProgramFlag()
        {
 
        }

        public Int64 IdProgramFlag
        {
            get { return _idProgramFlag; }
            set { _idProgramFlag = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String Pname
        {
            get { return _pname; }
            set { _pname = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
