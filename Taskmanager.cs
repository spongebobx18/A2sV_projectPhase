using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// Enum to represent task categories
public enum TaskCategory
{
    Personal,
    Work,
    Errands,
    Others
}

// Task class with properties
public class TaskItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategory Category { get; set; }
    public bool IsCompleted { get; set; }
}

// Task Manager class
public class TaskManager
{
    private List<TaskItem> tasks;

    public TaskManager()
    {
        tasks = new List<TaskItem>();
    }

    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
    }

    public void ViewTasks()
    {
        Console.WriteLine("Tasks:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"Name: {task.Name},\n ,  Description: {task.Description}, \n,  Category: {task.Category},\n,  Completed: {task.IsCompleted}");
        }
    }

    public void ViewTasksByCategory(TaskCategory category)
    {
        var filteredTasks = tasks.Where(task => task.Category == category);
        Console.WriteLine($"Tasks in {category} category:");
        foreach (var task in filteredTasks)
        {
            Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, Completed: {task.IsCompleted}");
        }
    }

    // Async methods for file operations
    public async Task SaveTasksToFileAsync(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var task in tasks)
            {
                await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
            }
        }
    }

    public async Task LoadTasksFromFileAsync(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] parts = line.Split(',');
                        TaskItem task = new TaskItem
                        {
                            Name = parts[0],
                            Description = parts[1],
                            Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), parts[2]),
                            IsCompleted = bool.Parse(parts[3])
                        };
                        tasks.Add(task);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = "C:\\Users\\Vida\\Desktop\\tasks.csv"; // File path for storing tasks
        TaskManager taskManager = new TaskManager();

        // Load tasks from file asynchronously
        await taskManager.LoadTasksFromFileAsync(filePath);

        // Display menu options
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. View Tasks by Category");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter task name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("Select task category:");
                    foreach (var category in Enum.GetValues(typeof(TaskCategory)))
                    {
                        Console.WriteLine($"{(int)category}. {category}");
                    }
                    Console.Write("Enter category number: ");
                    int categoryNumber = int.Parse(Console.ReadLine());
                    TaskCategory selectedCategory = (TaskCategory)categoryNumber;
                    TaskItem newTask = new TaskItem { Name = name, Description = description, Category = selectedCategory, IsCompleted = false };
                    taskManager.AddTask(newTask);
                    break;
                case "2":
                    taskManager.ViewTasks();
                    break;
                case "3":
                    Console.WriteLine("Select category to filter:");
                    foreach (var cat in Enum.GetValues(typeof(TaskCategory)))
                    {
                        Console.WriteLine($"{(int)cat}. {cat}");
                    }
                    Console.Write("Enter category number: ");
                    categoryNumber = int.Parse(Console.ReadLine());
                    selectedCategory = (TaskCategory)categoryNumber;
                    taskManager.ViewTasksByCategory(selectedCategory);
                    break;
                case "4":
                    // Save tasks to file before exiting
                    await taskManager.SaveTasksToFileAsync(filePath);
                    Console.WriteLine("Tasks saved successfully. Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}