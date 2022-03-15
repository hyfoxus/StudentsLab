// See https://aka.ms/new-console-template for more information

namespace StudentsLab
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TeacherService teacherService = new TeacherService();
            Teacher ivanov = new Teacher();
            ivanov.name = "Иванов";
            ivanov = teacherService.Create(ivanov);
            
            
            StudentService studentService = new StudentService();
            Student student = new Student();
            student.name = "Глеб";
            student = studentService.Create(student);
            
            
            Lesson lesson = new Lesson();
            LessonService lessonService = new LessonService();
            lessonService.Create(lesson, student, ivanov);
            
            
        }
    }
}

