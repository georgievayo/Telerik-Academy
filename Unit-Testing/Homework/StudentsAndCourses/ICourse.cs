namespace StudentsAndCourses
{
    public interface ICourse
    {
        void JoinCourse(IStudent student);
        void LeaveCourse(IStudent student);
    }
}