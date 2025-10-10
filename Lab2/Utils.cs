namespace Lab2_;

public static class Utils
{
    public static void ShowInfo(object obj)
    {
        switch (obj)
        {
            case Task t:
                Console.WriteLine($"Task: {t.Title}, Status: {(t.IsCompleted ? "Completat" : "In curs")}");
                break;
            case Project p:
                Console.WriteLine($"Proiect: {p.Name}, Numar de sarcini: {p.Tasks.Count}");
                break;
            default:
                Console.WriteLine("Tip necunoscut");
                break;
        }
    }
}