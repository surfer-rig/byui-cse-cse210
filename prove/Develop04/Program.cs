using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    private string _name;
    private string _description;
    private int _duration; // in seconds

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
        PerformActivity();
        End();
    }

    protected abstract void PerformActivity();

    private void End()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            foreach (var symbol in new[] { "|", "/", "-", "\\" })
            {
                Console.Write(symbol);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected int Duration => _duration;
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") 
    { }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write("\nBreathe in... ");
            Countdown(4);
            elapsed += 4;

            if (elapsed >= Duration) break;

            Console.Write("Breathe out... ");
            Countdown(6);
            elapsed += 6;
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private static readonly string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine($"\n{prompts[rand.Next(prompts.Length)]}\n");
        ShowSpinner(4);

        int elapsed = 0;
        while (elapsed < Duration)
        {
            string question = questions[rand.Next(questions.Length)];
            Console.WriteLine($"\n{question}");
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private static readonly string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine($"\nList as many responses as you can to: {prompt}");
        Console.WriteLine("You may begin in:");
        Countdown(3);

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
                new BreathingActivity().Start();
            else if (choice == "2")
                new ReflectionActivity().Start();
            else if (choice == "3")
                new ListingActivity().Start();
            else if (choice == "4")
                break;
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to continue.");
                Console.ReadLine();
            }
        }
    }
}
