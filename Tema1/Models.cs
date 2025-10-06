namespace Tema1;

public record Student(int Id, string Name, int Age, List<Course>  Courses);
public record Course(string Title, int Credits);
public class Instructor
{
    public string Name { get; init; }
    public string Department { get; init; }
    public string Email { get; init; }
};