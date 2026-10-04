using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PostType
    {
        private int postTypeId;

        public int PostTypeId
        {
            get { return postTypeId; }
            set { postTypeId = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int is_Active;

        public int Is_Active
        {
            get { return is_Active; }
            set { is_Active = value; }
        }
    }
}
