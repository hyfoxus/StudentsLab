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

    public Student Create(Student s)
    {
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
}