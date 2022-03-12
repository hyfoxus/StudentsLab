namespace StudentsLab;

public class SenseiService
{
    private List<Sensei> senseis = new List<Sensei>();
    public SubjectService StudentService = new SubjectService();
    public TeacherService TeacherService = new TeacherService();
   
    
    public List<Teacher> GetAllBySubject(Guid id)
    {
        List<Teacher> teachers = new List<Teacher>();
        foreach (Sensei sensei in senseis)
        {
            if (sensei.subject.id == id)
            {
                teachers.Add(sensei.teacher);
            }
        }
        return teachers;
    }
    public List<Subject> GetAllByTeacher(Guid id)
    {
        List<Subject> subjects = new List<Subject>();
        foreach (Sensei sensei in senseis)
        {
            if (sensei.teacher.id == id)
            {
                subjects.Add(sensei.subject);
            }
        }
        return subjects;
    }

    public Sensei Get(Guid idTeacher, Guid idSubject)
    {
        foreach (Sensei sensei in senseis)
        {
            if (sensei.subject.id == idSubject && sensei.teacher.id == idTeacher)
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

    public Sensei Create(Sensei sensei, Subject subject, Teacher teacher)
    {
        sensei.teacher = teacher;
        sensei.subject = subject;
        senseis.Add(sensei);
        return sensei;
    }
    
    

    public void Delete(Sensei sensei)
    {
        senseis.Remove(sensei);
    }
    
    
}