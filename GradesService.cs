using Newtonsoft.Json;

namespace StudentsLab;

public class GradesService
{
    public List<Grade> Grades = new List<Grade>();

    
    public SenseiService SenseiService { get; set; }
    public LessonService LessonService { get; set; }
    public ApprenticeService ApprenticeService { get; set; }
    public GradesService(ApprenticeService ApprenticeService, SenseiService SenseiService, LessonService LessonService)
    {
        this.ApprenticeService = ApprenticeService;
        this.LessonService = LessonService;
        this.SenseiService = SenseiService;
    }


    public List<int> GetAllByStudent(Guid id)
    {
        List<int> studentGrades = new List<int>();
        foreach (Grade grade in Grades)
        {
            if (grade.idStudent == id)
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
            if (grade.idTeacher == id)
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

    public Grade Create( Guid teacher, Guid student, Guid examiner, Guid subject, int value)
    // Guid idTeacher, idStudent, idExaminer, idSubject
    {
        Grade grade = new Grade();
        bool checker = false;
        foreach (Guid teacherId in SenseiService.GetAllBySubject(subject) )
        {
            if (teacher == teacherId && teacher != examiner)
            {
                grade.idTeacher = teacher;
                checker = true;
            }
        }
        if (!checker)
        {
            Console.WriteLine("Экзаменатор и преподаватель совпадают или этот предмет не ведет препод");
            return null;
        }
        checker = false;
        
        foreach (Guid subjectId in ApprenticeService.GetAllByStudent(student))
        {
            if (subjectId == subject)
            {
                grade.idSubject = subject;
                checker = true;
            }
        }
        
        if (!checker)
        {
            Console.WriteLine("Такого предмета нет у данного студента");
            return null;
        }
        
        checker = false;
        foreach (Guid studentId in LessonService.GetAllByTeacher(teacher))
        {
            if (studentId == student)
            {
                grade.idSubject = subject;
                checker = true;
            }
            
        }
        if(!checker){
            Console.WriteLine("Такого студента нет у этого учителя");
            return null;
        }
        
        checker = false;
        foreach (Guid examinerId in SenseiService.GetAllBySubject(subject))
        {
            if (examiner == examinerId)
            {
                grade.idExaminer = examiner;
                checker = true;
            }
 
        }
        if(!checker){
            Console.WriteLine("Этот экзаменатор не преподает этот предмет");
            return null;
        }
        
        checker = false;

        // grade.idTeacher = teacher;
        // grade.idExaminer = examiner;
        // grade.idStudent = student;
        // grade.idSubject = subject;
        
        grade.grade = value;
        
        Grades.Add(grade);
        return grade;
    }

    public Grade GetGrade(Guid idTeacher, Guid idStudent, Guid idSubject)
    //Teacher teacher, Student student, Subject subject
    {
        foreach (Grade grade in Grades)
        {
            if (grade.idTeacher == idTeacher && idStudent == grade.idStudent && grade.idSubject == idSubject)
            {
                return grade;
            }
        }
        Console.WriteLine("Такого экзамена не было!");
        return null;
    }

    public void DeleteByTeacher(Guid teacher)
    {
        foreach (Grade grade in Grades)
        {
            if (grade.idStudent == teacher)
            {
                Grades.Remove(grade);
            }
        }
    }
    public void DeleteByStudent(Guid student)
    {
        foreach (Grade grade in Grades)
        {
            if (grade.idStudent == student)
            {
                Grades.Remove(grade);
            }
        }
    }
    public void DeleteBySubject(Guid subject)
    {
        foreach (Grade grade in Grades)
        {
            if (grade.idSubject == subject)
            {
                Grades.Remove(grade);
            }
        }
    }

    public void SaveSession()
    {
        //string _fileName = DateTime.Today.ToString() + "_ExamResults.json";
        string _fileName = "Grades.json";
        string _jsonString = JsonConvert.SerializeObject(Grades, Formatting.Indented);
        File.WriteAllText(_fileName, _jsonString);
    }

    public void LoadSession()
    {
        string _fileName = "Grades.json";
        if (File.Exists(_fileName))
        {
            var _jsonString = File.ReadAllText(_fileName);

            Grades = JsonConvert.DeserializeObject<List<Grade>>(_jsonString);
        }
        else
        {
            Console.WriteLine(_fileName + " doesn't exist!");
            
        }

        
    }

}