using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOCategory
    {
        Int64 _idCategory;
        String _mscName;
        String _categoryName;
        Int64 _idFather;

        public DTOCategory()
        {
 
        }

        public Int64 IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }

        public String MscName
        {
            get { return _mscName; }
            set { _mscName = value; }
        }

        public String CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        public Int64 IdFather
        {
            get { return _idFather; }
            set { _idFather = value; }
        }
    }
}
