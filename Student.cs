namespace StudentsLab;

public class Student:Origin
{
    
    public string name { get; set; }
    
    public double GetRating(GradesService grades, Guid studentId)
    {
        double rating;
        int sum = 0;
        int n = 0;
        
        foreach (int i in grades.GetAllByStudent(studentId))
        {
            sum += i;
            n++;
        }

        rating = sum / n;
        return rating;
    }

}