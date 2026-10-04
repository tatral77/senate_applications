using Entities;
using ManBIZ;
using ManEntities;
using QuestionBIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuestionManagement
{
    public partial class CompareQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack==true)
            bindFields();
        }
        protected string GetCriteria()
        {
            string query = "";

            if (FromAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.SESSION_NUMBER>=" + FromAssemblySessionDDL.SelectedItem.Value;

            }
            //if (GenderDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " SYSTEM_USERS.GENDER=" + GenderDDL.SelectedItem.Value;

            //}
            //if (ReligionDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " SYSTEM_USERS.RELIGIONS_ID=" + ReligionDDL.SelectedItem.Value;

            //}
            //if (NotReligionDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " SYSTEM_USERS.RELIGIONS_ID<>" + NotReligionDDL.SelectedItem.Value;

            //}
            if (ToAssemblySessionDDL.SelectedItem.Value != "0")
            {
                if (query != "")
                    query += " AND ";
                query += " QUESTIONS.SESSION_NUMBER<=" + ToAssemblySessionDDL.SelectedItem.Value;

            }
            //if (!(String.IsNullOrEmpty(QuestionId.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTIONS.QUESTIONS_ID IN (" + QuestionId.Text + ")";

            //}
            //if (!(String.IsNullOrEmpty(QuestionDiary.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTIONS.QUESTION_DIARY_NO = ('" + QuestionDiary.Text + "')";

            //}

            //if (QuestionStatusDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTIONS.QUESTION_STATUS=" + QuestionStatusDDL.SelectedItem.Value;

            //}

            //if (CategoryDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTION_CATEGORY=" + CategoryDDL.SelectedItem.Value;

            //}
            //if (GroupsDDL.SelectedItem.Value != "0")
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += "(GROUPS.GROUP_SEQUENCE = (SELECT GROUP_SEQUENCE FROM GROUPS AS GROUPS_1 WHERE (GROUPS_ID = " + GroupsDDL.SelectedItem.Value + ")))";
            //    // query += "  MINISTRY_GROUP=" + GroupsDDL.SelectedItem.Value;

            //}
            //if (!(String.IsNullOrEmpty(MemberNameTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " MOVER=" + HidMemberId.Value;

            //}
            //if (!(String.IsNullOrEmpty(DivisionTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " DIVISION=" + HidDivisionId.Value;

            //}
            //if (!(String.IsNullOrEmpty(KeywordsTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTION_TEXT LIKE '%" + KeywordsTxt.Text + "%'";

            //}
            //if (!(String.IsNullOrEmpty(NoticeDiaryNo.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTIONS.NOTICE_DIARY_NO  IN (" + NoticeDiaryNo.Text + ") ";

            //}
            //if (!(String.IsNullOrEmpty(DateFromTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTIONS.NOTICE_DIARY_DATE>=CONVERT(DATETIME, '" + DateFromTxt.Text + "', 104)";

            //}
            //if (!(String.IsNullOrEmpty(DateToTxt.Text)))
            //{
            //    if (query != "")
            //        query += " AND ";
            //    query += " QUESTIONS.NOTICE_DIARY_DATE<=CONVERT(DATETIME, '" + DateToTxt.Text + "', 104)";

            //}

            if (query != "")
                query += " AND ";
            query += " IS_DELETED=0 ";




            return query;


        }
        protected List<Questions> search()
        {
            string criteria = GetCriteria();
            List<Questions> Questions = null;
            if (GetCriteria() != String.Empty)
            { 
                string query = "SELECT QUESTIONS.QUESTIONS_ID,QUESTIONS.LIST_NO, QUESTIONS.PARLIAMENTARY_YEAR, QUESTIONS.MOVER, QUESTIONS.QUESTION_CATEGORY,QUESTIONS.STATUS_DATE, QUESTIONS.QUESTION_DATE, QUESTIONS.QUESTION_TIME, QUESTIONS.SUBJECT, ";
                query += " QUESTIONS.QUESTION_TEXT, QUESTIONS.MINISTRY, QUESTIONS.MINISTRY_GROUP, QUESTIONS.DIVISION,DIVISIONS.DESCRIPTION AS DIVISION_NAME, QUESTIONS.DEPARTMENTS_ID, QUESTIONS.NOTICE_DIARY_NO, QUESTIONS.NOTICE_DIARY_DATE, QUESTIONS.REPLY_DATE,  ";
                query += " QUESTIONS.NOTICE_DIARY_TIME, QUESTIONS.ADMITTED_NUMBER,QUESTIONS.IS_CARRY_FWD, QUESTIONS.QUESTION_DIARY_NO, QUESTIONS.QUESTION_DIARY_DATE, QUESTIONS.QUESTION_DIARY_TIME, QUESTIONS.SESSION_NUMBER,  ";
                query += " QUESTIONS.SESSION_SITTINGS_ID, CONCAT(SYSTEM_USERS.F_NAME,' ' ,SYSTEM_USERS.M_NAME,' ',SYSTEM_USERS.L_NAME) AS F_NAME, QUESTION_STATUSES.DESCRIPTION AS QUESTION_STATUS, QUESTION_CATEGORIES.DESCRIPTION AS CATEGORY,ASSEMBLY_SESSIONS.SESSION_NUMBER AS SESSION_NAME,GROUPS.GROUP_SEQUENCE,QUESTIONS.DELETED_BY,QUESTIONS.DELETION_DATE,QUESTIONS.DEVICE_ID ";
                query += "  FROM QUESTIONS INNER JOIN  ";
                query += " QUESTION_CATEGORIES ON QUESTIONS.QUESTION_CATEGORY = QUESTION_CATEGORIES.QUESTION_CATEGORIES_ID INNER JOIN  ";
                query += " QUESTION_STATUSES ON QUESTIONS.QUESTION_STATUS = QUESTION_STATUSES.QUESTION_STATUSES_ID INNER JOIN  ";
                query += " DIVISIONS ON QUESTIONS.DIVISION = DIVISIONS.DIVISIONS_ID INNER JOIN  ";
                query += " SYSTEM_USERS ON QUESTIONS.MOVER = SYSTEM_USERS.SYSTEM_USERS_ID INNER JOIN ";
                query += " ASSEMBLY_SESSIONS ON QUESTIONS.SESSION_NUMBER = ASSEMBLY_SESSIONS.ASSEMBLY_SESSIONS_ID INNER JOIN";
                query += "  GROUPS ON QUESTIONS.MINISTRY_GROUP = GROUPS.GROUPS_ID ";
                if (GetCriteria() != String.Empty)
                {
                    query += " WHERE ";
                    query += GetCriteria();
                }
                // query += " ORDER BY QUESTIONS.REPLY_DATE  ";
                query += " ORDER BY QUESTIONS.NOTICE_DIARY_DATE DESC,QUESTIONS.NOTICE_DIARY_TIME,QUESTIONS.NOTICE_DIARY_NO  ";
                Questions = new QuestionBiz().SearchQuestion(query);
              
               
            }
            return Questions;
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            
            List<Questions> questions= search();
            
            string QuestionToCompare = QuestionToCompareTxt.Text;
            int PercentageToCompare = Convert.ToInt32(PercentageToCompareDDL.SelectedValue);
            if (!String.IsNullOrEmpty(QuestionToCompare))
            {
                if (questions != null)
                {
                    List<Questions> SimilarQuestions = new List<Questions>();
                    foreach (Questions question in questions)
                    {
                        string q = StripHTML(question.QuestionText);
                        double matchresult = CompareStrings(QuestionToCompare, q);
                        // percentagelbl.Text = matchresult.ToString();
                        if (matchresult > PercentageToCompare)
                        {
                            question.MatchingPercentage = matchresult;
                            SimilarQuestions.Add(question);
                        }
                    }

                    ListView1.DataSource = SimilarQuestions.OrderByDescending(qn=>qn.MatchingPercentage);
                    ListView1.DataBind();
                }

            }


        }



        protected string RemoveMostUsedWords(string text)
        {
            string[] arrToCheck = new string[] {",", "\"\"","\"","so","minister","pleased","whether","state","0o", "0s", "3a", "3b", "3d", "6b", "6o", "a", "a1", "a2", "a3", "a4", "ab", "able", "about", "above", "abst", "ac", "accordance", "according", "accordingly", "across", "act", "actually", "ad", "added", "adj", "ae", "af", "affected", "affecting", "affects", "after", "afterwards", "ag", "again", "against", "ah", "ain", "ain't", "aj", "al", "all", "allow", "allows", "almost", "alone", "along", "already", "also", "although", "always", "am", "among", "amongst", "amoungst", "amount", "an", "and", "announce", "another", "any", "anybody", "anyhow", "anymore", "anyone", "anything", "anyway", "anyways", "anywhere", "ao", "ap", "apart", "apparently", "appear", "appreciate", "appropriate", "approximately", "ar", "are", "aren", "arent", "aren't", "arise", "around", "as", "a's", "aside", "ask", "asking", "associated", "at", "au", "auth", "av", "available", "aw", "away", "awfully", "ax", "ay", "az", "b", "b1", "b2", "b3", "ba", "back", "bc", "bd", "be", "became", "because", "become", "becomes", "becoming", "been", "before", "beforehand", "begin", "beginning", "beginnings", "begins", "behind", "being", "believe", "below", "beside", "besides", "best", "better", "between", "beyond", "bi", "bill", "biol", "bj", "bk", "bl", "bn", "both", "bottom", "bp", "br", "brief", "briefly", "bs", "bt", "bu", "but", "bx", "by", "c", "c1", "c2", "c3", "ca", "call", "came", "can", "cannot", "cant", "can't", "cause", "causes", "cc", "cd", "ce", "certain", "certainly", "cf", "cg", "ch", "changes", "ci", "cit", "cj", "cl", "clearly", "cm", "c'mon", "cn", "co", "com", "come", "comes", "con", "concerning", "consequently", "consider", "considering", "contain", "containing", "contains", "corresponding", "could", "couldn", "couldnt", "couldn't", "course", "cp", "cq", "cr", "cry", "cs", "c's", "ct", "cu", "currently", "cv", "cx", "cy", "cz", "d", "d2", "da", "date", "dc", "dd", "de", "definitely", "describe", "described", "despite", "detail", "df", "di", "did", "didn", "didn't", "different", "dj", "dk", "dl", "do", "does", "doesn", "doesn't", "doing", "don", "done", "don't", "down", "downwards", "dp", "dr", "ds", "dt", "du", "due", "during", "dx", "dy", "e", "e2", "e3", "ea", "each", "ec", "ed", "edu", "ee", "ef", "effect", "eg", "ei", "eight", "eighty", "either", "ej", "el", "eleven", "else", "elsewhere", "em", "empty", "en", "end", "ending", "enough", "entirely", "eo", "ep", "eq", "er", "es", "especially", "est", "et", "et-al", "etc", "eu", "ev", "even", "ever", "every", "everybody", "everyone", "everything", "everywhere", "ex", "exactly", "example", "except", "ey", "f", "f2", "fa", "far", "fc", "few", "ff", "fi", "fifteen", "fifth", "fify", "fill", "find", "fire", "first", "five", "fix", "fj", "fl", "fn", "fo", "followed", "following", "follows", "for", "former", "formerly", "forth", "forty", "found", "four", "fr", "from", "front", "fs", "ft", "fu", "full", "further", "furthermore", "fy", "g", "ga", "gave", "ge", "get", "gets", "getting", "gi", "give", "given", "gives", "giving", "gj", "gl", "go", "goes", "going", "gone", "got", "gotten", "gr", "greetings", "gs", "gy", "h", "h2", "h3", "had", "hadn", "hadn't", "happens", "hardly", "has", "hasn", "hasnt", "hasn't", "have", "haven", "haven't", "having", "he", "hed", "he'd", "he'll", "hello", "help", "hence", "her", "here", "hereafter", "hereby", "herein", "heres", "here's", "hereupon", "hers", "herself", "hes", "he's", "hh", "hi", "hid", "him", "himself", "his", "hither", "hj", "ho", "home", "hopefully", "how", "howbeit", "however", "how's", "hr", "hs", "http", "hu", "hundred", "hy", "i", "i2", "i3", "i4", "i6", "i7", "i8", "ia", "ib", "ibid", "ic", "id", "i'd", "ie", "if", "ig", "ignored", "ih", "ii", "ij", "il", "i'll", "im", "i'm", "immediate", "immediately", "importance", "important", "in", "inasmuch", "inc", "indeed", "index", "indicate", "indicated", "indicates", "information", "inner", "insofar", "instead", "interest", "into", "invention", "inward", "io", "ip", "iq", "ir", "is", "isn", "isn't", "it", "itd", "it'd", "it'll", "its", "it's", "itself", "iv", "i've", "ix", "iy", "iz", "j", "jj", "jr", "js", "jt", "ju", "just", "k", "ke", "keep", "keeps", "kept", "kg", "kj", "km", "know", "known", "knows", "ko", "l", "l2", "la", "largely", "last", "lately", "later", "latter", "latterly", "lb", "lc", "le", "least", "les", "less", "lest", "let", "lets", "let's", "lf", "like", "liked", "likely", "line", "little", "lj", "ll", "ll", "ln", "lo", "look", "looking", "looks", "los", "lr", "ls", "lt", "ltd", "m", "m2", "ma", "made", "mainly", "make", "makes", "many", "may", "maybe", "me", "mean", "means", "meantime", "meanwhile", "merely", "mg", "might", "mightn", "mightn't", "mill", "million", "mine", "miss", "ml", "mn", "mo", "more", "moreover", "most", "mostly", "move", "mr", "mrs", "ms", "mt", "mu", "much", "mug", "must", "mustn", "mustn't", "my", "myself", "n", "n2", "na", "name", "namely", "nay", "nc", "nd", "ne", "near", "nearly", "necessarily", "necessary", "need", "needn", "needn't", "needs", "neither", "never", "nevertheless", "new", "next", "ng", "ni", "nine", "ninety", "nj", "nl", "nn", "no", "nobody", "non", "none", "nonetheless", "noone", "nor", "normally", "nos", "not", "noted", "nothing", "novel", "now", "nowhere", "nr", "ns", "nt", "ny", "o", "oa", "ob", "obtain", "obtained", "obviously", "oc", "od", "of", "off", "often", "og", "oh", "oi", "oj", "ok", "okay", "ol", "old", "om", "omitted", "on", "once", "one", "ones", "only", "onto", "oo", "op", "oq", "or", "ord", "os", "ot", "other", "others", "otherwise", "ou", "ought", "our", "ours", "ourselves", "out", "outside", "over", "overall", "ow", "owing", "own", "ox", "oz", "p", "p1", "p2", "p3", "page", "pagecount", "pages", "par", "part", "particular", "particularly", "pas", "past", "pc", "pd", "pe", "per", "perhaps", "pf", "ph", "pi", "pj", "pk", "pl", "placed", "please", "plus", "pm", "pn", "po", "poorly", "possible", "possibly", "potentially", "pp", "pq", "pr", "predominantly", "present", "presumably", "previously", "primarily", "probably", "promptly", "proud", "provides", "ps", "pt", "pu", "put", "py", "q", "qj", "qu", "que", "quickly", "quite", "qv", "r", "r2", "ra", "ran", "rather", "rc", "rd", "re", "readily", "really", "reasonably", "recent", "recently", "ref", "refs", "regarding", "regardless", "regards", "related", "relatively", "research", "research-articl", "respectively", "resulted", "resulting", "results", "rf", "rh", "ri", "right", "rj", "rl", "rm", "rn", "ro", "rq", "rr", "rs", "rt", "ru", "run", "rv", "ry", "s", "s2", "sa", "said", "same", "saw", "say", "saying", "says", "sc", "sd", "se", "sec", "second", "secondly", "section", "see", "seeing", "seem", "seemed", "seeming", "seems", "seen", "self", "selves", "sensible", "sent", "serious", "seriously", "seven", "several", "sf", "shall", "shan", "shan't", "she", "shed", "she'd", "she'll", "shes", "she's", "should", "shouldn", "shouldn't", "should've", "show", "showed", "shown", "showns", "shows", "si", "side", "significant", "significantly", "similar", "similarly", "since", "sincere", "six", "sixty", "sj", "sl", "slightly", "sm", "sn", "so", "some", "somebody", "somehow", "someone", "somethan", "something", "sometime", "sometimes", "somewhat", "somewhere", "soon", "sorry", "sp", "specifically", "specified", "specify", "specifying", "sq", "sr", "ss", "st", "still", "stop", "strongly", "sub", "substantially", "successfully", "such", "sufficiently", "suggest", "sup", "sure", "sy", "system", "sz", "t", "t1", "t2", "t3", "take", "taken", "taking", "tb", "tc", "td", "te", "tell", "ten", "tends", "tf", "th", "than", "thank", "thanks", "thanx", "that", "that'll", "thats", "that's", "that've", "the", "their", "theirs", "them", "themselves", "then", "thence", "there", "thereafter", "thereby", "thered", "therefore", "therein", "there'll", "thereof", "therere", "theres", "there's", "thereto", "thereupon", "there've", "these", "they", "theyd", "they'd", "they'll", "theyre", "they're", "they've", "thickv", "thin", "think", "third", "this", "thorough", "thoroughly", "those", "thou", "though", "thoughh", "thousand", "three", "throug", "through", "throughout", "thru", "thus", "ti", "til", "tip", "tj", "tl", "tm", "tn", "to", "together", "too", "took", "top", "toward", "towards", "tp", "tq", "tr", "tried", "tries", "truly", "try", "trying", "ts", "t's", "tt", "tv", "twelve", "twenty", "twice", "two", "tx", "u", "u201d", "ue", "ui", "uj", "uk", "um", "un", "under", "unfortunately", "unless", "unlike", "unlikely", "until", "unto", "uo", "up", "upon", "ups", "ur", "us", "use", "used", "useful", "usefully", "usefulness", "uses", "using", "usually", "ut", "v", "va", "value", "various", "vd", "ve", "ve", "very", "via", "viz", "vj", "vo", "vol", "vols", "volumtype", "vq", "vs", "vt", "vu", "w", "wa", "want", "wants", "was", "wasn", "wasnt", "wasn't", "way", "we", "wed", "we'd", "welcome", "well", "we'll", "well-b", "went", "were", "we're", "weren", "werent", "weren't", "we've", "what", "whatever", "what'll", "whats", "what's", "when", "whence", "whenever", "when's", "where", "whereafter", "whereas", "whereby", "wherein", "wheres", "where's", "whereupon", "wherever", "whether", "which", "while", "whim", "whither", "who", "whod", "whoever", "whole", "who'll", "whom", "whomever", "whos", "who's", "whose", "why", "why's", "wi", "widely", "will", "willing", "wish", "with", "within", "without", "wo", "won", "wonder", "wont", "won't", "words", "world", "would", "wouldn", "wouldnt", "wouldn't", "www", "x", "x1", "x2", "x3", "xf", "xi", "xj", "xk", "xl", "xn", "xo", "xs", "xt", "xv", "xx", "y", "y2", "yes", "yet", "yj", "yl", "you", "youd", "you'd", "you'll", "your", "youre", "you're", "yours", "yourself", "yourselves", "you've", "yr", "ys", "yt", "z", "zero", "zi", "zz", };
            // string[] arrToCheck = new string[] { "is", "this" };
            string input = text.ToLower();
            foreach (string word in arrToCheck)
            {
                input = input.Replace(" " + word + " ", " ");
            }
            return input;
        }
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
        public double CompareStrings(string str1, string str2)
        {
            double similarwordscount = 0;
            List<String> pairs1 = WordLetterPairs(RemoveMostUsedWords(str1)).Distinct().ToList();
            List<String> pairs2 = WordLetterPairs(RemoveMostUsedWords(str2)).Distinct().ToList();
            foreach(String s1 in pairs1)
            {
                foreach(String s2 in pairs2)
                {
                    if (s1.Equals(s2))
                    {
                        similarwordscount += 1;
                    }
                }
            }

            double TextToCompare = pairs1.Count();
            double QuestionToCompare= pairs2.Count();
            double len = 0;
            if (TextToCompare > QuestionToCompare)
                len = TextToCompare;
            else
                len = QuestionToCompare;
            double percentage = (similarwordscount / len) * 100;
            return percentage;




            //int intersection = 0;
            //int union = pairs1.Count + pairs2.Count;

            //for (int i = 0; i < pairs1.Count; i++)
            //{
            //    for (int j = 0; j < pairs2.Count; j++)
            //    {
            //        if (pairs1[i] == pairs2[j])
            //        {
            //            intersection++;
            //            pairs2.RemoveAt(j);//Must remove the match to prevent "AAAA" from appearing to match "AA" with 100% success
            //            break;
            //        }
            //    }
            //}
            //double result= (2.0 * intersection * 100) / union; //returns in percentage
            //return result;
                                                       //return (2.0 * intersection) / union; //returns in score from 0 to 1
        }
        private List<String> WordLetterPairs(string str)
        {
            List<String> AllPairs = new List<String>();

            // Tokenize the string and put the tokens/words into an array
            List<String> Words = Regex.Split(str, @"\s").ToList();

            //// For each word
            //for (int w = 0; w < Words.Length; w++)
            //{
            //    if (!string.IsNullOrEmpty(Words[w]))
            //    {
            //        // Find the pairs of characters
            //        String[] PairsInWord = LetterPairs(Words[w]);

            //        for (int p = 0; p < PairsInWord.Length; p++)
            //        {
            //            AllPairs.Add(PairsInWord[p]);
            //        }
            //    }
            //}
            return Words;
        }
        public string GetLink(string QuestionId)
        {
            string link = "~/QuestionDetails.aspx?QuestionsId=" + QuestionId;
            if (Request.Cookies["userInfo"] != null)
            {
                HttpCookie userInfo = Request.Cookies["userInfo"];
                string role = Convert.ToString(userInfo["role"]);
                if (role.Equals("SO"))
                    link = "~/QuestionDetailsRest.aspx?QuestionsId=" + QuestionId;
            }
            return link;

        }

        private string[] LetterPairs(string str)
        {
            int numPairs = str.Length - 1;
            string[] pairs = new string[numPairs];

            for (int i = 0; i < numPairs; i++)
            {
                pairs[i] = str.Substring(i, 2);
            }
            return pairs;
        }
        public string GetUserName(int UserId)
        {
            User user = new ManBiz().GetUser(UserId);
            if (user != null)
            {
                return user.FullName;
            }
            return "";
        }
        public string GetGroupName(int GroupId)
        {
            Groups gp = new QuestionBiz().GetGroupById(GroupId);
            if (gp != null)
                return gp.Description;
            else
                return "Not Mentioned";

        }
        public string GetTime(DateTime time)
        {
            return time.ToShortTimeString();
        }
        public string GetDate(DateTime date)
        {
            if (date < Convert.ToDateTime("01/01/1900"))
                return "";
            else
                return date.ToShortDateString();

        }
        private void bindFields()
        {
            AssemblySessions ASession = new AdministrationBiz().GetCurrentAssemblySessionDetails();
            // SessionMovementDDL.Items.Add(new ListItem("Select", "0"));
            List<AssemblySessions> ASessions = new AdministrationBiz().GetAssemblySessions();
           
            foreach (AssemblySessions row in ASessions)
            {
                ListItem li = new ListItem();
                li.Text = row.SessionNumber.ToString();
                li.Value = row.AssemblySessionsId.ToString();
                FromAssemblySessionDDL.Items.Add(li);
                ToAssemblySessionDDL.Items.Add(li);
                //if (row.AssemblySessionsId == ASession.AssemblySessionsId)
                //    SessionMovementDDL.Items.Add(li);
            }

            for(int i=1;i<=100;i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString();
                li.Value = i.ToString();
                PercentageToCompareDDL.Items.Add(li);
            }
            PercentageToCompareDDL.SelectedValue = "50";
            //FromAssemblySessionDDL.SelectedIndex = 1;
            //ToAssemblySessionDDL.SelectedIndex = 1;

            //List<QuestionCategories> QCats = new AdministrationBiz().GetQuestionCategories();
            //foreach (QuestionCategories row in QCats)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.QuestionCategoriesId.ToString();
            //    CategoryDDL.Items.Add(li);
            //}



            //List<QuestionStatuses> QStatuses = new AdministrationBiz().GetQuestionActiveStatus();
            //foreach (QuestionStatuses row in QStatuses)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = row.Description;
            //    li.Value = row.QuestionStatusesId.ToString();
            //    QuestionStatusDDL.Items.Add(li);
            //}

            //List<QuestionStatuses> ChStatuses = new AdministrationBiz().GetQuestionActiveStatus();
            //foreach (QuestionStatuses items in ChStatuses)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = items.Description;
            //    li.Value = items.QuestionStatusesId.ToString();
            //    ChangeStatusDDL.Items.Add(li);
            //}

        }
        
    }
}