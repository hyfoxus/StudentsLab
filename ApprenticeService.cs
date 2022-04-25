using Newtonsoft.Json;

namespace StudentsLab;

public class ApprenticeService
{
    public List<Apprentice> apprentices = new List<Apprentice>();

    public StudentService StudentService { get; set; }
    public SubjectService SubjectService { get; set; }
    public ApprenticeService(StudentService StudentService, SubjectService SubjectService)
    {
        this.StudentService = StudentService;
        this.SubjectService = SubjectService;
    }


    public List<Guid> GetAllByStudent(Guid id)
    {
        List<Guid> subjectsId = new List<Guid>();
        foreach (Apprentice apprentice in apprentices)
        {
            if (apprentice.studentId == id)
            {
                subjectsId.Add(apprentice.subjectId);
            }
        }
        return subjectsId;
    }
    public List<Guid> GetAllBySubject(Guid id)
    {
        List<Guid> studentsId = new List<Guid>();
        foreach (Apprentice apprentice in apprentices)
        {
            if (apprentice.subjectId == id)
            {
                studentsId.Add(apprentice.studentId);
            }
        }
        return studentsId;
    }

    public Apprentice Get(Guid idSubject, Guid idStudent)
    {
        foreach (Apprentice apprentice in apprentices)
        {
            if (apprentice.studentId == idStudent && apprentice.subjectId == idSubject)
            {
                return apprentice;
            }
        }
        Console.WriteLine("Это преподаватель не преподает этот предмет, чтобы получить List всех его предметов воспользуйтесь методом GetByTeacher");
        return null;
    }
    
    public List<Apprentice> GetAll()
    {
        return apprentices;
    }

    public Apprentice Create( Guid student, Guid subject)
    {
        Apprentice apprentice = new Apprentice();
        apprentice.subjectId = subject;
        apprentice.studentId = student;
        apprentices.Add(apprentice);
        return apprentice;
    }
    
    

    public void Delete(Apprentice apprentice)
    {
        apprentices.Remove(apprentice);
    }
    public void SaveSession()
    {
        string _fileName = "Apprentices.json";
        string _jsonString = JsonConvert.SerializeObject(apprentices, Formatting.Indented);
        File.WriteAllText(_fileName, _jsonString);
    }
    public void LoadSession()
    {
        string _fileName = "Apprentices.json";
        
        if (File.Exists(_fileName))
        {
            var _jsonString = File.ReadAllText(_fileName);

            apprentices = JsonConvert.DeserializeObject<List<Apprentice>>(_jsonString);
        }
        else
        {
            Console.WriteLine(_fileName + " doesn't exist!");
            
        }
    }
}