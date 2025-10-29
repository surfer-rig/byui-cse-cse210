public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return _points;
        }
        return 0;
    }

    public override string GetDetails()
    {
        return $"[{(_completed ? "X" : " ")}] {_name} - {_description}";
    }

    public override string Serialize()
    {
        return $"Simple|{_name}|{_description}|{_points}|{_completed}";
    }
}