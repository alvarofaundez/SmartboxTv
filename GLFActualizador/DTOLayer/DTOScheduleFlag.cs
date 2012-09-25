using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOScheduleFlag
    {
        Int64 _idScheduleFlag;
        String _name;
        String _pname;
        String _description;

        public DTOScheduleFlag()
        {
 
        }

        public Int64 IdScheduleFlag
        {
            get { return _idScheduleFlag; }
            set { _idScheduleFlag = value; }
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
