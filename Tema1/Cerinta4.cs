namespace Tema1
{
    public static class Cerinta4
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
            
            var instructor = new Instructor
            {
                Name = "Florin",
                Department = ".NET",
                Email = "florin.olariu@gmail.com"
            };

            var student = new Student(1, "Razvan", 21, cursuri);
            
            Func(instructor); // Tip Necunoscut
            Func(student); // afiseaza date student
            Func(new Course(".NET", 6));
        }
        
        static void Func(object obj)
        {
            switch (obj)
            {
                case Student student:
                    Console.WriteLine($"Nume: {student.Name}, Numarul de cursuri: {student.Courses.Count}");
                    break;
                case Course course:
                    Console.WriteLine($"Nume curs: {course.Title}, Numar de credite: {course.Credits}");
                    break;
                default:
                    Console.WriteLine("Tip Necunoscut");
                    break;
            }
        }
    }
}