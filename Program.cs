// See https://aka.ms/new-console-template for more information

namespace StudentsLab
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TeacherService teacherService = new TeacherService();
            teacherService.LoadSession();
            Teacher ivanov = teacherService.Create("Иванов");
            
            
            Teacher exam = teacherService.Create("Димас");

            
            
            StudentService studentService = new StudentService();
            studentService.LoadSession();
            
            Student student = studentService.Create("Степан");
    
            
            SubjectService subjectService = new SubjectService();
            subjectService.LoadSession();
            Subject chemistry = subjectService.Create("Хуимия");


            
            LessonService lessonService = new LessonService(studentService, teacherService);
            lessonService.LoadSession();
            //lessonService.Create(student.id, exam.id);
            lessonService.Create(student.id, ivanov.id);
           
            ApprenticeService apprenticeService = new ApprenticeService(studentService, subjectService);
            apprenticeService.Create(student.id, chemistry.id);

            SenseiService senseiService = new SenseiService(subjectService, teacherService);
            senseiService.Create(chemistry.id, ivanov.id);
            senseiService.Create(chemistry.id, exam.id);
            GradesService gradesService = new GradesService(apprenticeService, senseiService, lessonService);

            gradesService.Create(ivanov.id, student.id, exam.id, chemistry.id, 99);
            System.Console.WriteLine(ivanov.GetRating(gradesService, ivanov.id));
            
            

            SaveAll(apprenticeService, senseiService, lessonService, teacherService, studentService, subjectService, gradesService);
            
        }

        public static void SaveAll(ApprenticeService apprenticeService, 
                            SenseiService senseiService,
                            LessonService lessonService,
                            TeacherService teacherService,
                            StudentService studentService,
                            SubjectService subjectService,
                            GradesService gradesService)
        {
            apprenticeService.SaveSession();
            senseiService.SaveSession();
            lessonService.SaveSession();
            teacherService.SaveSession();
            studentService.SaveSession();
            subjectService.SaveSession();
            gradesService.SaveSession();
        }
    }
    
    
}

