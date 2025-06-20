namespace SchoolManagementSystem.Models
{
    public class Mark
    {
        public int MarkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ExamId { get; set; }
        public int MarksObtained { get; set; }
    }
}
