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

    public Subject Create(Subject s)
    {
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
}