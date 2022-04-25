using Newtonsoft.Json;

namespace StudentsLab;

public class SenseiService
{
    private List<Sensei> senseis = new List<Sensei>();


    public SenseiService(SubjectService SubjectService, TeacherService TeacherService)
    {
        this.SubjectService = SubjectService;
        this.TeacherService = TeacherService;
    }

    public SubjectService SubjectService { get; set; }
    public TeacherService TeacherService { get; set; }
    public List<Guid> GetAllBySubject(Guid id)
    {
        List<Guid> teachersId = new List<Guid>();
        foreach (Sensei sensei in senseis)
        {
            if (sensei.subjectId == id)
            {
                teachersId.Add(sensei.teacherId);
            }
        }
        return teachersId;
    }
    public List<Guid> GetAllByTeacher(Guid id)
    {
        List<Guid> subjectsId = new List<Guid>();
        foreach (Sensei sensei in senseis)
        {
            if (sensei.teacherId == id)
            {
                subjectsId.Add(sensei.subjectId);
            }
        }
        return subjectsId;
    }

    public Sensei Get(Guid idTeacher, Guid idSubject)
    {
        foreach (Sensei sensei in senseis)
        {
            if (sensei.subjectId == idSubject && sensei.teacherId == idTeacher)
            {
                return sensei;
            }
        }
        Console.WriteLine("Это преподаватель не преподает этот предмет, чтобы получить List всех его предметов воспользуйтесь методом GetByTeacher");
        return null;
    }
    
    public List<Sensei> GetAll()
    {
        return senseis;
    }

    public Sensei Create(Guid subject, Guid teacher)
    {
        Sensei sensei = new Sensei();
        sensei.teacherId = teacher;
        sensei.subjectId = subject;
        senseis.Add(sensei);
        return sensei;
    }
    
    

    public void Delete(Sensei sensei)
    {
        senseis.Remove(sensei);
    }
    
    public void SaveSession()
    {
        string _fileName = "Senseis.json";
        string _jsonString = JsonConvert.SerializeObject(senseis, Formatting.Indented);
        File.WriteAllText(_fileName, _jsonString);
    }
    public void LoadSession()
    {
        string _fileName = "Senseis.json";

        if (File.Exists(_fileName))
        {
            var _jsonString = File.ReadAllText(_fileName);

            senseis = JsonConvert.DeserializeObject<List<Sensei>>(_jsonString);
        }
        else
        {
            Console.WriteLine(_fileName + " doesn't exist!");
            
        }
    }
    
}