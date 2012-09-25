using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOChannel
    {
        private Int64 _idChannel;
        private String _callLetter;
        private String _channelName;
        private Int32 _idType;

        public DTOChannel()
        {
 
        }

        public Int64 IdChannel
        {
            get { return _idChannel; }
            set { _idChannel = value; }
        }

        public String CallLetter
        {
            get { return _callLetter; }
            set { _callLetter = value; }
        }

        public String ChannelName
        {
            get { return _channelName; }
            set { _channelName = value; }
        }

        public Int32 IdType
        {
            get { return _idType; }
            set { _idType = value; }
        }
    }
}
