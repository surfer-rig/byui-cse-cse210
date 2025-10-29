using System;

// Address class
class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Base Event class
class Event
{
    private string title;
    private string description;
    private string date;
    private string time;
    private Address address;

    public Event(string title, string description, string date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    // Methods common to all events
    public virtual string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date}\nTime: {time}\nAddress:\n{address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails(); // base class only knows standard details
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: Generic\nTitle: {title}\nDate: {date}";
    }
}

// Lecture class
class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nEvent Type: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Lecture\nTitle: {baseTitle()}\nDate: {baseDate()}";
    }

    private string baseTitle()
    {
        // Using reflection for simplicity; could also store title as protected
        return typeof(Event).GetProperty("title", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this).ToString();
    }

    private string baseDate()
    {
        return typeof(Event).GetProperty("date", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this).ToString();
    }
}

// Reception class
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nEvent Type: Reception\nRSVP Email: {rsvpEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Reception\nTitle: {baseTitle()}\nDate: {baseDate()}";
    }

    private string baseTitle()
    {
        return typeof(Event).GetProperty("title", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this).ToString();
    }

    private string baseDate()
    {
        return typeof(Event).GetProperty("date", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this).ToString();
    }
}

// OutdoorGathering class
class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $"\nEvent Type: Outdoor Gathering\nWeather Forecast: {weatherForecast}";
    }

    public override string GetShortDescription()
    {
        return $"Event Type: Outdoor Gathering\nTitle: {baseTitle()}\nDate: {baseDate()}";
    }

    private string baseTitle()
    {
        return typeof(Event).GetProperty("title", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this).ToString();
    }

    private string baseDate()
    {
        return typeof(Event).GetProperty("date", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this).ToString();
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address addr1 = new Address("123 Main St", "New York", "NY", "USA");
        Address addr2 = new Address("456 Oak Ave", "Los Angeles", "CA", "USA");
        Address addr3 = new Address("789 Pine Rd", "Miami", "FL", "USA");

        // Create events
        Lecture lectureEvent = new Lecture("Tech Talk", "Learn about C#", "2025-11-01", "18:00", addr1, "Dr. Smith", 100);
        Reception receptionEvent = new Reception("Networking Reception", "Meet professionals in your field", "2025-11-05", "19:00", addr2, "rsvp@events.com");
        OutdoorGathering outdoorEvent = new OutdoorGathering("Beach Cleanup", "Help clean up the local beach", "2025-11-10", "09:00", addr3, "Sunny with light winds");

        // Array of events
        Event[] events = { lectureEvent, receptionEvent, outdoorEvent };

        // Display details for each event
        foreach (Event e in events)
        {
            Console.WriteLine("=== Standard Details ===");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine("\n=== Full Details ===");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine("\n=== Short Description ===");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine(new string('-', 50));
        }
    }
}
