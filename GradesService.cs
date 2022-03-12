namespace StudentsLab;

public class GradesService
{
    public List<Grade> Grades = new List<Grade>();
    private ApprenticeService ApprenticeService = new ApprenticeService();
    private SenseiService SenseiService = new SenseiService();
    private LessonService LessonService = new LessonService();



    public List<int> GetAllByStudent(Guid id)
    {
        List<int> studentGrades = new List<int>();
        foreach (Grade grade in Grades)
        {
            if (grade.student.id == id)
            {
                studentGrades.Add(grade.grade);
            }
        }

        return studentGrades;
    }
    public List<int> GetAllByTeacher(Guid id)
    {
        List<int> teacherGrades = new List<int>();
        foreach (Grade grade in Grades)
        {
            if (grade.teacher.id == id)
            {
                teacherGrades.Add(grade.grade);
            }
        }

        return teacherGrades;
    }

    public List<Grade> GetAll()
    {
        return Grades;
    }

    public Grade Create(Grade grade, Teacher teacher, Student student, Teacher examiner, Subject subject, int mark)
    {
        
        foreach (Teacher teacheroid in SenseiService.GetAllBySubject(subject.id) )
        {
            if (teacher.id == teacheroid.id && teacher.id != examiner.id)
            {
                grade.teacher = teacher;
            }
        }

        foreach (Subject subjectoid in ApprenticeService.GetAllByStudent(student.id))
        {
            if (subjectoid.id == subject.id)
            {
                grade.subject = subject;
            }
        }

        foreach (Student studentoid in LessonService.GetAllByTeacher(teacher.id))
        {
            if (studentoid.id == student.id)
            {
                grade.subject = subject;
            }
        }

        foreach (Teacher examineroid in SenseiService.GetAllBySubject(subject.id))
        {
            if (examiner.id == examineroid.id)
            {
                grade.examiner = examiner;
            }
            
        }

        Random rnd = new Random();
        grade.grade = rnd.Next();
        
        if (grade.examiner != null && grade.student != null && grade.teacher != null && grade.subject != null)
        {
            Grades.Add(grade);
            return grade;
        }
        else
        {
            Console.WriteLine("Криворукое ЧМО");
            return null;
        }

        
    }

   
    
    
}