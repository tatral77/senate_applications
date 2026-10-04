using System;

namespace Entities
{
    public class FileStatusHiostory

    {
        public int FileStatusHistoryId { get; set; }
        public int QuestionsId { get; set; }
        public int FileStatusId { get; set; }
        public string FileStatus { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime StatusHistoryDate { get; set; }

    }
}
