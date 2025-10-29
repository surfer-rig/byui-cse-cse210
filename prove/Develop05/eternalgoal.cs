public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override string GetDetails()
    {
        return $"[∞] {_name} - {_description}";
    }

    public override string Serialize()
    {
        return $"Eternal|{_name}|{_description}|{_points}";
    }
}
