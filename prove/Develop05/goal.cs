public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetDetails();
    public abstract string Serialize();

    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string type = parts[0];

        return type switch
        {
            "Simple" => new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])),
            "Eternal" => new EternalGoal(parts[1], parts[2], int.Parse(parts[3])),
            "Checklist" => new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])),
            _ => null
        };
    }
}
