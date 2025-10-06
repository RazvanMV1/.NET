namespace Tema1
{
    public static class Cerinta1
    {
        public static void Run()
        {
            var cursuri = new List<Course> 
            { 
                new Course(".NET", 6), 
                new Course("AI", 6) 
            };
            var cursuri2 = new List<Course> 
            { 
                new Course("ML", 5), 
                new Course("Security", 4) 
            };

            var student = new Student(1, "Razvan", 21, cursuri);
            var studentNou = student with { Courses = cursuri2 };

            Console.WriteLine($"Student original: {student.Name}, numar cursuri: {student.Courses.Count}");
            Console.WriteLine($"Student nou: {studentNou.Name}, numar cursuri: {studentNou.Courses.Count}");
        }
    }
}

