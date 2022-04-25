using Newtonsoft.Json;

namespace StudentsLab;

public class SubjectService
{
    private List<Subject> subjects = new List<Subject>();
    public Subject Get(Guid id)
    {
        foreach (Subject subject in subjects)
        {
            if (subject.id == id)
            {
                return subject;
            }
        }
        Console.WriteLine("Такого преподавателя НЕТ!");
        return null;
    }

    public List<Subject> GetAll()
    {
        return subjects;
    }

    public Subject Create(string name)
    {
        Subject s = new Subject();
        s.name = name;
        s.id = Guid.NewGuid();
        subjects.Add(s);
        return s;
    }

    public void Delete(Guid id)
    {
        foreach (Subject subject in subjects)
        {
            if (subject.id == id)
            {
                subjects.Remove(subject);
            }
        }
    }
    public void SaveSession()
    {
        string _fileName = "Subjects.json";
        string _jsonString = JsonConvert.SerializeObject(subjects, Formatting.Indented);
        File.WriteAllText(_fileName, _jsonString);
    }
    public void LoadSession()
    {
        string _fileName = "Subjects.json";
        if (File.Exists(_fileName))
        {
            var _jsonString = File.ReadAllText(_fileName);

            subjects = JsonConvert.DeserializeObject<List<Subject>>(_jsonString);
        }
        else
        {
            Console.WriteLine(_fileName + " doesn't exist!");
        }
    }
}