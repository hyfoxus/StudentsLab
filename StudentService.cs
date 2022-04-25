using Newtonsoft.Json;

namespace StudentsLab;

public class StudentService
{
    private List<Student> students = new List<Student>();
    
    public Student Get(Guid id)
    {
        foreach (Student student in students)
        {
            if (student.id == id)
            {
                return student;
            }
        }
        Console.WriteLine("Такого студента НЕТ!");
        return null;
    }

    public List<Student> GetAll()
    {
        return students;
    }

    public Student Create(string name)
    {
        Student s = new Student();
        s.name = name;
        s.id = Guid.NewGuid();
        students.Add(s);
        return s;
    }


    public void Delete(Guid id)
    {
        foreach (Student student in students)
        {
            if (student.id == id)
            {
                students.Remove(student);
            }
        }
    }
    public void SaveSession()
    {
        string _fileName = "Students.json";
        string _jsonString = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(_fileName, _jsonString);
        
        
    }
    
    public void LoadSession()
    {
        string _fileName = "Students.json";

        if (File.Exists(_fileName))
        {
            var _jsonString = File.ReadAllText(_fileName);
            students = JsonConvert.DeserializeObject<List<Student>>(_jsonString);
        }
        else
        {
            Console.WriteLine(_fileName + " doesn't exist!");
            
        }
    }
        

}
