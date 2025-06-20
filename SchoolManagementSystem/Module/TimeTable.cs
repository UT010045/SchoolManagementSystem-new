namespace SchoolManagementSystem.Models
{
    public class Timetable
    {
        public int TimetableId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public string Day { get; set; } 
        public string StartTime { get; set; } 
        public string EndTime { get; set; }
    }
}
