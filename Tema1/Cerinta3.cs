namespace Tema1
{
    public static class Cerinta3
    {
        public static void Run()
        {
            Console.Write("Name: ");
            var name = Console.ReadLine();

            var listStudenti = new List<String>();
            listStudenti.Add(name);

            foreach (var studenti in listStudenti)
            {
                Console.WriteLine(studenti);
            }
        }
    }
}