namespace StudentsLab;

public class LessonService
{
    private List<Lesson> lessons = new List<Lesson>();
    public StudentService StudentService = new StudentService();
    public TeacherService TeacherService = new TeacherService();
   
    
    public List<Teacher> GetAllByStudent(Guid id)
    {
        List<Teacher> teachers = new List<Teacher>();
        foreach (Lesson lesson in lessons)
        {
            if (lesson.student.id == id)
            {
                teachers.Add(lesson.teacher);
            }
        }
        return teachers;
    }
    public List<Student> GetAllByTeacher(Guid id)
    {
        List<Student> students = new List<Student>();
        foreach (Lesson lesson in lessons)
        {
            if (lesson.teacher.id == id)
            {
                students.Add(lesson.student);
            }
        }
        return students;
    }

    public Lesson Get(Guid idTeacher, Guid idStudent)
    {
        foreach (Lesson lesson in lessons)
        {
            if (lesson.student.id == idStudent && lesson.teacher.id == idTeacher)
            {
                return lesson;
            }
        }
        Console.WriteLine("Это преподаватель не преподает этот предмет, чтобы получить List всех его предметов воспользуйтесь методом GetByTeacher");
        return null;
    }
    
    public List<Lesson> GetAll()
    {
        return lessons;
    }

    public Lesson Create(Lesson lesson, Student student, Teacher teacher)
    {
        lesson.teacher = teacher;
        lesson.student = student;
        lessons.Add(lesson);
        return lesson;
    }
    
    

    public void Delete(Lesson lesson)
    {
        lessons.Remove(lesson);
    }

}