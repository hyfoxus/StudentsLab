using Newtonsoft.Json;

namespace StudentsLab;

public class LessonService
{
    private List<Lesson> lessons = new List<Lesson>();
    public TeacherService TeacherService { get; set; }
    public StudentService StudentService { get; set; }
    public LessonService(StudentService StudentService, TeacherService TeacherService)
    {
        this.TeacherService = TeacherService;
        this.StudentService = StudentService;
    }


    public List<Guid> GetAllByStudent(Guid id)
    {
        List<Guid> teachersId = new List<Guid>();
        foreach (Lesson lesson in lessons)
        {
            if (lesson.studentId == id)
            {
                teachersId.Add(lesson.teacherId);
            }
        }
        return teachersId;
    }
    public List<Guid> GetAllByTeacher(Guid id)
    {
        List<Guid> studentsId = new List<Guid>();
        foreach (Lesson lesson in lessons)
        {
            if (lesson.teacherId == id)
            {
                studentsId.Add(lesson.studentId);
            }
        }
        return studentsId;
    }

    public Lesson Get(Guid idTeacher, Guid idStudent)
    {
        foreach (Lesson lesson in lessons)
        {
            if (lesson.studentId == idStudent && lesson.teacherId == idTeacher)
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

    public Lesson Create( Guid student, Guid teacher)
    {
        Lesson lesson = new Lesson();
        lesson.teacherId = teacher;
        lesson.studentId = student;
        lessons.Add(lesson);
        return lesson;
    }
    
    

    public void Delete(Lesson lesson)
    {
        lessons.Remove(lesson);
    }
    
    public void SaveSession()
    {
        string _fileName = "Lessons.json";
        string _jsonString = JsonConvert.SerializeObject(lessons, Formatting.Indented);
        File.WriteAllText(_fileName, _jsonString);
    }
    public void LoadSession()
    {
        string _fileName = "Lessons.json";
        if (File.Exists(_fileName))
        {
            var _jsonString = File.ReadAllText(_fileName);

            lessons = JsonConvert.DeserializeObject<List<Lesson>>(_jsonString);
        }
        else
        {
            Console.WriteLine(_fileName + " doesn't exist!");
            
        }

        
    }
    
}