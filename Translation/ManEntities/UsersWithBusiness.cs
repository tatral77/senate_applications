using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManEntities
{
    public class UsersWithBusiness:User
    {
        public int Questions { get; set; } = 0;
        public int Resolutions { get; set; } = 0;
        public int Motions { get; set; } = 0;
        public int PendingQuestions { get; set; }
        public int TranslatedQuestions { get; set; }
    }
}
