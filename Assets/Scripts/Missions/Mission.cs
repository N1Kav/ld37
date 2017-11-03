using System;

[Serializable]
public class Mission
{
    private MissionScriptableObject _pattern;
    private int _currentCheckpointIndex;

    public Mission(MissionScriptableObject pattern)
    {
        _pattern = pattern;
        _currentCheckpointIndex = 0;
    }
}
