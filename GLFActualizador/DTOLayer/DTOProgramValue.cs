using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOProgramValue
    {

        Int64 _idProgramValue;
        String _name;
        String _pname;
        String _description;

        public DTOProgramValue()
        {
 
        }

        public Int64 IdProgramValue
        {
            get { return _idProgramValue; }
            set { _idProgramValue = value; }
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
