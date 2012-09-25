using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOProgramActorRole
    {
        private Int64 _idProgram;
        private Int64 _idActor;
        private Int64 _idRole;
        private Int32 _order;

        public Int32 Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public Int64 IdRole
        {
            get { return _idRole; }
            set { _idRole = value; }
        }

        public Int64 IdActor
        {
            get { return _idActor; }
            set { _idActor = value; }
        }

        public Int64 IdProgram
        {
            get { return _idProgram; }
            set { _idProgram = value; }
        }
    }
}
