using System;

class Task
{
    public string Description { get; set; }
    public int Priority { get; set; }
}

class Scheduler 
{
    private Queue<Task> taskQueue = new Queue<Task>();

    public void AddTask(string description, int priority)
    {
        var newTask = new Task { Description = description, Priority = priority };
        
        var tempList = taskQueue.ToList();
        tempList.Add(newTask);
        
        tempList = tempList.OrderBy(t => t.Priority).ToList();
        
        taskQueue = new Queue<Task>(tempList);
        Console.WriteLine($"Задача {description} добавлена!");
    }

    public Task GetNextTask()
    {
        if (taskQueue.Count > 0)
            return taskQueue.Peek();
        else
            Console.WriteLine("Задач не осталось");
            return null;
    }

    public void ProcessTasks()
    {
        while (taskQueue.Count > 0)
        {
            Task task = taskQueue.Dequeue();
            Console.WriteLine($"Выполняется: {task.Description} (Приоритет: {task.Priority})");
            Finally();
        }
    }

    public void ChangePriority(string description)
    {
        var taskList = taskQueue.ToList();
        var task = taskList.FirstOrDefault(t => t.Description == description);

        if (task != null)
        {
            taskList.Remove(task);
            taskList.Insert(0, task);
            taskQueue = new Queue<Task>(taskList);
        }
        Console.WriteLine($"Порядок изменён: задача {task.Description} стоит выше в приоритете");
    }
    public void Finally()
    {
        if (taskQueue.Count == 0)
        {
            Console.WriteLine("Список задач пуст");
        }
        {
            Console.WriteLine("Оставшиеся задачи в очереди:");
            foreach (var t in taskQueue)
            {
                Console.WriteLine($"{t.Description}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Scheduler scheduler = new Scheduler();

        scheduler.AddTask("Проверить почту", 2);
        scheduler.AddTask("Запустить антивирус", 1);
        scheduler.AddTask("Обновить систему", 3);

        Console.WriteLine("Следующая задача: " + scheduler.GetNextTask().Description);

        scheduler.ChangePriority("Обновить систему");

        scheduler.ProcessTasks();
    }
}