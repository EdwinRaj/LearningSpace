namespace CustomImplementations
{
    public class Student
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }

        public override string ToString()
        {
            return string.Format("StudentId: {0}, StudentName: {1}", StudentId, StudentName);
        }
    }
}
