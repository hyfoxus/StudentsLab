namespace StudentsLab;

public class Teacher:Origin
{
    public string name;

    public double GetRating(GradesService grades, Guid teacherId)
    {
        double rating;
        int sum = 0;
        int n = 0;
        
        foreach (int i in grades.GetAllByTeacher(teacherId))
        {
            sum += i;
            n++;
        }

        try
        {
            rating = sum / n;
        }
        catch (Exception ex)
        {
            return 0;
        }
        
        return rating;
    }

    
    
}