using QuestionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace QuestionBIZ
{
    public class SimilarQuestion
    {
        public int QuestionsId { get; set; }
        public string SessionNumber { get; set; }
        public string MoverName { get; set; }
        public string Status { get; set; }
        public string Division { get; set; }
        public int NoticeDiaryNo { get; set; }
        public DateTime NoticeDiaryDate { get; set; }
        public string Preview { get; set; }
        public string CommonWords { get; set; }
        public int Score { get; set; }          // 0-100
    }

    public class SimilarityResult
    {
        public bool TextTooShort { get; set; }   // not enough meaningful words typed yet to compare
        public int WordCount { get; set; }
        public List<SimilarQuestion> Matches { get; set; }
    }

    // Finds earlier questions that look like a new one.
    // Text is reduced to its meaningful words (HTML, punctuation and common words removed) and compared
    // using single words plus word pairs, so questions on the same topic that ask different things score lower.
    public class SimilarityBiz
    {
        public const int SessionsBack = 10;

        private static readonly HashSet<string> StopWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "a","about","above","after","again","against","all","also","am","an","and","any","are","as","at","be","because","been",
            "before","being","below","between","both","but","by","can","could","did","do","does","doing","down","during","each",
            "few","for","from","further","had","has","have","having","he","her","here","hers","him","his","how","i","if","in","into",
            "is","it","its","itself","just","me","more","most","my","no","nor","not","now","of","off","on","once","only","or","other",
            "our","ours","out","over","own","same","she","should","so","some","such","than","that","the","their","theirs","them","then",
            "there","these","they","this","those","through","to","too","under","until","up","very","was","we","were","what","when",
            "where","which","while","who","whom","why","will","with","would","you","your","yours",
            // wording that starts almost every parliamentary question
            "minister","pleased","state","whether","please","government","kindly","refer","regarding","respect","details","provide","reply","lay","house"
        };

        public List<SimilarQuestion> FindSimilar(string text, int currentSessionId, int thresholdPercent, int maxResults)
        {
            return Check(text, currentSessionId, thresholdPercent, maxResults).Matches;
        }

        public SimilarityResult Check(string text, int currentSessionId, int thresholdPercent, int maxResults)
        {
            List<SimilarQuestion> found = new List<SimilarQuestion>();
            List<string> words = Tokenize(text);
            if (words.Count < 3)                              // too little text to compare meaningfully
                return new SimilarityResult { TextTooShort = true, WordCount = words.Count, Matches = found };

            HashSet<string> mine = Features(words);
            HashSet<string> myWords = new HashSet<string>(words);

            foreach (SimilarityCandidate c in new SimilarityDAL().GetCandidates(currentSessionId, SessionsBack))
            {
                List<string> theirWords = Tokenize(c.QuestionText);
                if (theirWords.Count == 0) continue;

                HashSet<string> theirs = Features(theirWords);
                int shared = mine.Count < theirs.Count ? mine.Count(f => theirs.Contains(f)) : theirs.Count(f => mine.Contains(f));
                double dice = 2.0 * shared / (mine.Count + theirs.Count);   // 0..1
                int score = (int)Math.Round(dice * 100);
                if (score < thresholdPercent) continue;

                HashSet<string> theirSet = new HashSet<string>(theirWords);
                string common = string.Join(", ", myWords.Where(w => theirSet.Contains(w)).Take(10));
                found.Add(new SimilarQuestion
                {
                    QuestionsId = c.QuestionsId,
                    SessionNumber = c.SessionNumber,
                    MoverName = c.MoverName,
                    Status = c.Status,
                    Division = c.Division,
                    NoticeDiaryNo = c.NoticeDiaryNo,
                    NoticeDiaryDate = c.NoticeDiaryDate,
                    Preview = Preview(c.QuestionText),
                    CommonWords = common,
                    Score = score
                });
            }
            return new SimilarityResult
            {
                WordCount = words.Count,
                Matches = found.OrderByDescending(f => f.Score).ThenByDescending(f => f.QuestionsId).Take(maxResults).ToList()
            };
        }

        private static string PlainText(string html)
        {
            if (string.IsNullOrEmpty(html)) return "";
            string t = Regex.Replace(html, "<[^>]*>", " ");
            t = WebUtility.HtmlDecode(t);
            return Regex.Replace(t, @"\s+", " ").Trim();
        }

        private static string Preview(string html)
        {
            string t = PlainText(html);
            return t.Length <= 240 ? t : t.Substring(0, 240).TrimEnd() + "...";
        }

        // lower-case words, letters/digits only, common words removed (works for Urdu letters too)
        private static List<string> Tokenize(string html)
        {
            List<string> words = new List<string>();
            foreach (Match m in Regex.Matches(PlainText(html).ToLowerInvariant(), @"[\p{L}\p{N}]+"))
            {
                string w = m.Value;
                if (w.Length < 2 || StopWords.Contains(w)) continue;
                words.Add(w);
            }
            return words;
        }

        // single words and neighbouring word pairs
        private static HashSet<string> Features(List<string> words)
        {
            HashSet<string> f = new HashSet<string>(words);
            for (int i = 0; i + 1 < words.Count; i++) f.Add(words[i] + " " + words[i + 1]);
            return f;
        }
    }
}
