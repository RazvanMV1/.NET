namespace Tema1
{
    public static class Cerinta2
    {
        public static void Run()
        {
            var instructor = new Instructor
            {
                Name = "Florin",
                Department = ".NET",
                Email = "florin.olariu@gmail.com"
            };

            //instructor.Name = "Andrei";   !EROARE

            Console.WriteLine($"Nume: {instructor.Name}  -Departament: {instructor.Department} -Email: {instructor.Email}");
        }
    }
}