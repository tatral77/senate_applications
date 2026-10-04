using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class PostStatus
    {
        private int postStatusID;

        public int PostStatusID
        {
            get { return postStatusID; }
            set { postStatusID = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int isActive;

        public int IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

    }
}
