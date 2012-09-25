using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOScheduleValue
    {
        Int64 _idScheduleValue;
        String _name;
        String _pname;
        String _description;

        public DTOScheduleValue()
        {
 
        }

        public Int64 IdScheduleValue
        {
            get { return _idScheduleValue; }
            set { _idScheduleValue = value; }
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
