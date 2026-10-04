using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PostSubType
    {
        private int postSubTypeId;

        public int PostSubTypeId
        {
            get { return postSubTypeId; }
            set { postSubTypeId = value; }
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
