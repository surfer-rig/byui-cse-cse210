public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed = 0)
        : base(name, description, points)
    {
        _targetCount = target;
        _bonus = bonus;
        _timesCompleted = completed;
    }

    public override int RecordEvent()
    {
        if (_timesCompleted < _targetCount)
        {
            _timesCompleted++;
            return _timesCompleted == _targetCount ? _points + _bonus : _points;
        }
        return 0;
    }

    public override string GetDetails()
    {
        return $"[{(_timesCompleted >= _targetCount ? "X" : " ")}] {_name} - {_description} (Completed {_timesCompleted}/{_targetCount})";
    }

    public override string Serialize()
    {
        return $"Checklist|{_name}|{_description}|{_points}|{_targetCount}|{_bonus}|{_timesCompleted}";
    }
}
