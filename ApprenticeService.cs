namespace StudentsLab;

public class ApprenticeService
{
    public List<Apprentice> apprentices = new List<Apprentice>();
    public StudentService StudentService = new StudentService();
    public SubjectService SubjectService = new SubjectService();
   
    
    public List<Subject> GetAllByStudent(Guid id)
    {
        List<Subject> subjects = new List<Subject>();
        foreach (Apprentice apprentice in apprentices)
        {
            if (apprentice.student.id == id)
            {
                subjects.Add(apprentice.subject);
            }
        }
        return subjects;
    }
    public List<Student> GetAllBySubject(Guid id)
    {
        List<Student> students = new List<Student>();
        foreach (Apprentice apprentice in apprentices)
        {
            if (apprentice.subject.id == id)
            {
                students.Add(apprentice.student);
            }
        }
        return students;
    }

    public Apprentice Get(Guid idSubject, Guid idStudent)
    {
        foreach (Apprentice apprentice in apprentices)
        {
            if (apprentice.student.id == idStudent && apprentice.subject.id == idSubject)
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

    public Apprentice Create(Apprentice apprentice, Student student, Subject subject)
    {
        apprentice.subject = subject;
        apprentice.student = student;
        apprentices.Add(apprentice);
        return apprentice;
    }
    
    

    public void Delete(Apprentice apprentice)
    {
        apprentices.Remove(apprentice);
    }

}