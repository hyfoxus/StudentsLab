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

    public Teacher Create(Teacher t)
    {
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
}