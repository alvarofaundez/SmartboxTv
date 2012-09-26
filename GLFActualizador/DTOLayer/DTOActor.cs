using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOActor
    {
        //5465
        private Int64 _idActor;
        private String _firstName;
        private String _lastName;

        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public String FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public Int64 IdActor
        {
            get { return _idActor; }
            set { _idActor = value; }
        }
        
    }
}
