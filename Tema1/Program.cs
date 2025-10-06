using Tema1;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENIU TEMA 1 ===");
            Console.WriteLine("1 - Cerinta 1");
            Console.WriteLine("2 - Cerinta 2");
            Console.WriteLine("3 - Cerinta 3");
            Console.WriteLine("4 - Cerinta 4");
            Console.WriteLine("5 - Cerinta 5");
            Console.WriteLine("0 - Iesire");

            Console.Write("Alege o optiune: ");
            var input = Console.ReadLine();

            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Cerinta1.Run();
                    break;
                case "2":
                    Cerinta2.Run();
                    break;
                case "3":
                    Cerinta3.Run();
                    break;
                case "4":
                    Cerinta4.Run();
                    break;
                case "5":
                    Cerinta5.Run();
                    break;
                case "0":
                    Console.WriteLine("Byee!");
                    return;
                default:
                    Console.WriteLine("Optiune invalida, incearca din nou.");
                    break;
            }
        }
    }
}