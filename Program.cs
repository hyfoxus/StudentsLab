// See https://aka.ms/new-console-template for more information

namespace StudentsLab
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TeacherService teacherService = new TeacherService();
            teacherService.LoadSession();
            Teacher ivanov = new Teacher();

            
            Teacher exam = new Teacher();

            
            
            StudentService studentService = new StudentService();
            
            Student student = new Student();

            
            SubjectService subjectService = new SubjectService();
            
            Subject chemistry = new Subject();


            
            LessonService lessonService = new LessonService(studentService, teacherService);
            lessonService.LoadSession();
            //lessonService.Create(student.id, exam.id);

           
            ApprenticeService apprenticeService = new ApprenticeService(studentService, subjectService);
            apprenticeService.Create(student.id, chemistry.id);

            SenseiService senseiService = new SenseiService(subjectService, teacherService);
            senseiService.Create(chemistry.id, ivanov.id);
            senseiService.Create(chemistry.id, exam.id);
            GradesService gradesService = new GradesService(apprenticeService, senseiService, lessonService);

            gradesService.Create(ivanov.id, student.id, exam.id, chemistry.id, 100);
            System.Console.WriteLine(ivanov.GetRating(gradesService, ivanov.id));



            SaveAll(apprenticeService, senseiService, lessonService, teacherService, studentService, subjectService);
            
        }

        public static void SaveAll(ApprenticeService apprenticeService, 
                            SenseiService senseiService,
                            LessonService lessonService,
                            TeacherService teacherService,
                            StudentService studentService,
                            SubjectService subjectService)
        {
            apprenticeService.SaveSession();
            senseiService.SaveSession();
            lessonService.SaveSession();
            teacherService.SaveSession();
            studentService.SaveSession();
            subjectService.SaveSession();
        }
    }
    
    
}

