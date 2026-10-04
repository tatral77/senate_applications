namespace Entities
{
    public class MemberAttendance
    {
        public int MemberAttendanceId { get; set; }
        public int SessionSittingId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public int AttendanceStatusId { get; set; }
    }
}
