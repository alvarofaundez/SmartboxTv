using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTOLayer
{
    public class DTOProgram
    {
        private Int64 _idProgram;
        private String _title;
        private String _rTitle;
        private String _description;
        private String _rDescription;
        private String _episodeTitle;
        private Int64 _idCategory;

        public DTOProgram()
        {
 
        }

        public Int64 IdProgram
        {
            get { return _idProgram; }
            set { _idProgram = value; }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String RTitle
        {
            get { return _rTitle; }
            set { _rTitle = value; }
        }

        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public String RDescription
        {
            get { return _rDescription; }
            set { _rDescription = value; }
        }

        public String EpisodeTitle
        {
            get { return _episodeTitle; }
            set { _episodeTitle = value; }
        }

        public Int64 IdCategory
        {
            get { return _idCategory; }
            set { _idCategory = value; }
        }
    }
}
