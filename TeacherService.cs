using Newtonsoft.Json;

namespace StudentsLab;

public class TeacherService
{
    private List<Teacher> teachers = new List<Teacher>();
    public Teacher Get(Guid id)
    {
        foreach (Teacher teacher in teachers)
        {
            if (teacher.id == id)
            {
                return teacher;
            }
        }
        Console.WriteLine("Такого преподавателя НЕТ!");
        return null;
    }

    public List<Teacher> GetAll()
    {
        return teachers;
    }

    public Teacher Create(string name)
    {
        Teacher t = new Teacher();
        t.name = name;
        t.id = Guid.NewGuid();
        teachers.Add(t);
        return t;
    }

    public void Delete(Guid id)
    {
        foreach (Teacher teacher in teachers)
        {
            if (teacher.id == id)
            {
                teachers.Remove(teacher);
            }
        }
    }
    public void SaveSession()
    {
        string _fileName = "Teachers.json";
        string _jsonString = JsonConvert.SerializeObject(teachers, Formatting.Indented);
        File.WriteAllText(_fileName, _jsonString);
    }
    public void LoadSession()
    {
        string _fileName = "Teachers.json";


        if (File.Exists(_fileName)){

            var _jsonString = File.ReadAllText(_fileName);

            teachers = JsonConvert.DeserializeObject<List<Teacher>>(_jsonString);
        }
        else
        {
            Console.WriteLine(_fileName + " doesn't exist!");
        }
    }
    
}