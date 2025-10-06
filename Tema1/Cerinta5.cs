namespace Tema1
{
    public static class Cerinta5
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

            var listaCursuri = new List<Course>();
            listaCursuri.AddRange(cursuri);
            listaCursuri.AddRange(cursuri2);
            listaCursuri.Add(new Course("TraLaLa",2));

            Func<Course, bool> filtrare = static c => c.Credits > 3;

            var cursuriFiltrate = listaCursuri.Where(filtrare).ToList();

            foreach (var c in cursuriFiltrate)
            {
                Console.WriteLine($"Nume curs: {c.Title}, Credite: {c.Credits}");
            }
        }
    }
}