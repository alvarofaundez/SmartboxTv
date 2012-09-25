using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTORole
    {
        private Int64 _idRole;
        private String _title;
        private String _description;

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Int64 IdRole
        {
            get { return _idRole; }
            set { _idRole = value; }
        }
        
    }
}
