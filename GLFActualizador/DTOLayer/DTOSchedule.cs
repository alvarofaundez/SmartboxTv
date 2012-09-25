using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOSchedule
    {
        private Int64 _idSchedule;
        private DateTime _startDate;
        private DateTime _endDate;
        private Int64 _idProgram;
        private Int64 _idChannel;
        private Int64 _idRole;

        
        public Int64 IdSchedule
        {
            get { return _idSchedule; }
            set { _idSchedule = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public Int64 IdProgram
        {
            get { return _idProgram; }
            set { _idProgram = value; }
        }

        public Int64 IdChannel
        {
            get { return _idChannel; }
            set { _idChannel = value; }
        }
    }
}
