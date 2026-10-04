using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstablishmentENT
{
    public class Post
    {
        private int postID;

        public int PostID
        {
            get { return postID; }
            set { postID = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int postTypeId;

public int PostTypeId
{
  get { return postTypeId; }
  set { postTypeId = value; }
}
        

        private string postType;

public string PostType
{
  get { return postType; }
  set { postType = value; }
}
        private int gazNonGazId;

public int GazNonGazId
{
  get { return gazNonGazId; }
  set { gazNonGazId = value; }
}
        private string gazNonGaz;

public string GazNonGaz
{
  get { return gazNonGaz; }
  set { gazNonGaz = value; }
}
        private int postStatusId;

public int PostStatusId
{
  get { return postStatusId; }
  set { postStatusId = value; }
}
        private string postStatus;

public string PostStatus
{
  get { return postStatus; }
  set { postStatus = value; }
}
        private int scaleFrom;

public int ScaleFrom
{
  get { return scaleFrom; }
  set { scaleFrom = value; }
}
        private int scaleTo;

public int ScaleTo
{
  get { return scaleTo; }
  set { scaleTo = value; }
}
        private int numOfPosts;

public int NumOfPosts
{
  get { return numOfPosts; }
  set { numOfPosts = value; }
}

        private int is_active;

        public int Is_active
        {
            get { return is_active; }
            set { is_active = value; }
        }
        private int numOfEmp;

        public int NumOfEmp
        {
            get { return numOfEmp; }
            set { numOfEmp = value; }
        }
    }
}
