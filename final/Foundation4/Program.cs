using System;
using System.Collections.Generic;

// Base Activity class
abstract class Activity
{
    private DateTime date;
    private double lengthInMinutes;

    public Activity(DateTime date, double lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
    }

    public DateTime Date { get { return date; } }
    public double LengthInMinutes { get { return lengthInMinutes; } }

    // Virtual methods to be overridden in derived classes
    public abstract double GetDistance(); // miles or km
    public abstract double GetSpeed(); // mph or kph
    public abstract double GetPace(); // min per mile or min per km

    // Summary method
    public virtual string GetSummary()
    {
        return $"{date:dd MMM yyyy} {this.GetType().Name} ({lengthInMinutes} min) - " +
               $"Distance: {GetDistance():0.00} miles, Speed: {GetSpeed():0.00} mph, Pace: {GetPace():0.00} min per mile";
    }
}

// Running class
class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, double lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / distance;
    }
}

// Cycling class
class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, double lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * LengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

// Swimming class
class Swimming : Activity
{
    private int laps; // number of laps
    private const double LapLengthMeters = 50;
    private const double MetersToMiles = 0.000621371;

    public Swimming(DateTime date, double lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * LapLengthMeters * MetersToMiles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / GetDistance();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Running run1 = new Running(new DateTime(2025, 10, 28), 30, 3.0); // 3 miles in 30 minutes
        Cycling cycle1 = new Cycling(new DateTime(2025, 10, 28), 45, 12); // 12 mph for 45 min
        Swimming swim1 = new Swimming(new DateTime(2025, 10, 28), 60, 40); // 40 laps in 60 min

        // Put activities in a list
        List<Activity> activities = new List<Activity> { run1, cycle1, swim1 };

        // Display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine(new string('-', 50));
        }
    }
}
