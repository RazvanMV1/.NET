using Lab2_;
using TaskModel = Lab2_.Task;
using ShowInfo = Lab2_.Utils;

var manager = new Manager("Razvan", "Backend Team", "razvan.vasile14@yahoo.com");
Console.WriteLine($"\nManager: {manager.Name}, Echipa: {manager.Team}, Email: {manager.Email}");
Console.Write("\n");

List<TaskModel> tasks = new()
{
    new TaskModel("Design database schema", false, DateTime.Now.AddDays(7)),
    new TaskModel("Implement authentication", true, DateTime.Now.AddDays(3)),
    new TaskModel("Set up CI/CD pipeline", false, DateTime.Now.AddDays(10))
};

Project project = new("New Website", tasks);

List<TaskModel> tasksNew = new(project.Tasks)
{
    new TaskModel("Write unit tests", false, DateTime.Now.AddDays(5)),
    new TaskModel("Fix production bug", false, DateTime.Now.AddDays(-2)) //intarziata
};

Project projectNew = project with { Tasks = tasksNew };

// Marcam o sarcina ca si completata

Console.Write("Titlu: ");
string? title = Console.ReadLine();

if (string.IsNullOrWhiteSpace(title))
{
    Console.WriteLine("Titlu invalid.");
    return;
}

for (int i = 0; i < projectNew.Tasks.Count; i++)
{
    if (projectNew.Tasks[i].Title.Equals(title, StringComparison.OrdinalIgnoreCase))
    {
        var completedTask = projectNew.Tasks[i] with { IsCompleted = true };
        projectNew.Tasks[i] = completedTask;
        Console.Write($"Sarcina '{title}' a fost marcata ca si completata.");
        break;
    }
}

Console.Write("\n");
Console.WriteLine("\nToate sarcinile:");
foreach (TaskModel task in projectNew.Tasks)
{
    Console.WriteLine($"Titlu: {task.Title}, Completata: {task.IsCompleted}, Data limita: {task.DueDate}");
}

Console.WriteLine("\nInformatii detaliate:");

ShowInfo.ShowInfo(projectNew);
ShowInfo.ShowInfo(projectNew.Tasks[0]);

Func<TaskModel, bool> overduePredicate = static t => !t.IsCompleted && t.DueDate < DateTime.Now;

var overdueTasks = projectNew.Tasks.Where(overduePredicate).ToList();

Console.WriteLine("\nSarcini intarziate:");

foreach (var t in overdueTasks)
{
    Console.WriteLine($"- {t.Title} (termen: {t.DueDate})");
}
